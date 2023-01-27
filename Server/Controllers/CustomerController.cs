using BlazorDemoCRUD.Service;
using Microsoft.AspNetCore.Mvc;

namespace BlazorDemoCRUD.Server.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [Route("api/v1/customer")]
        async public Task<IActionResult> CustomerCreate([FromBody] Common.Customer model)
        {
            var result = await _customerService.CustomerCreate(model);
            if(result.Success == false)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("api/v1/customer/{customerId}")]
        async public Task<IActionResult> CustomerGetById(string customerId)
        {
            var customer = await _customerService.CustomerGetById(customerId);
            if (customer == null)
                return BadRequest("Customer not found");

            return Ok(customer);
        }

        [HttpPut]
        [Route("api/v1/customer/{customerId}")]
        async public Task<IActionResult> CustomerUpdateById([FromBody] Common.Customer model, string customerId)
        {
            var result = await _customerService.CustomerUpdateById(model, customerId);

            if(result.Success == false)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Data);
        }

        [HttpDelete]
        [Route("api/v1/customer/{customerId}")]
        async public Task<IActionResult> CustomerDeleteById(string customerId)
        {
            await _customerService.CustomerDeleteById(customerId);

            return Ok();
        }


        [HttpPost]
        [Route("api/v1/customers")]
        async public Task<IActionResult> CustomerSearch([FromBody] Common.Search model)
        {
            var searchResponse = await _customerService.CustomerSearch(model);
            
            return Ok(searchResponse);
        }

        [HttpGet]
        [Route("api/v1/seed/create/{number}")]
        async public Task<IActionResult> SeedCustomers(int number)
        {
            for (int a = 0; a < number; a++)
            {
                var customer = new Common.Customer()
                {
                    Name = LoremNET.Lorem.Words(2),
                    Gender = (Common.Enumerations.Gender)LoremNET.Lorem.Number(0, 2),
                    Email = LoremNET.Lorem.Email(),
                    Phone = LoremNET.Lorem.Number(1111111111, 9999999999).ToString(),
                    Address = $"{LoremNET.Lorem.Number(100, 10000).ToString()} {LoremNET.Lorem.Words(1)}",
                    City = LoremNET.Lorem.Words(1),
                    State = LoremNET.Lorem.Words(1),
                    Postal = LoremNET.Lorem.Number(11111, 99999).ToString(),
                    BirthDate = LoremNET.Lorem.DateTime(1923, 1, 1),
                    Notes = LoremNET.Lorem.Paragraph(5, 10, 10),
                    Active = LoremNET.Lorem.Number(0, 1) == 0 ? false : true
                };

                await _customerService.CustomerCreate(customer);
            }

            return Ok();
        }

    }//End Controller
}
