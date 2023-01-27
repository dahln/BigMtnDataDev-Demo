using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Blazored.Modal;
using Blazored.Toast;
using BlazorSpinner;
using BlazorDemoCRUD.Client;
using BlazorDemoCRUD.Client.Services;
using System.Net.Http.Json;
using System.Security.AccessControl;
using static System.Net.Mime.MediaTypeNames;
using Blazored.SessionStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddHttpClient("API", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"));

builder.Services.AddScoped<API>();
builder.Services.AddScoped<SpinnerService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredSessionStorage();

await builder.Build().RunAsync();

