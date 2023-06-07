[![CI/CD Azure App Service](https://github.com/shadowlings/BlazorDemoCRUD-Lite/actions/workflows/main_blazordemocrud-lite.yml/badge.svg)](https://github.com/shadowlings/BlazorDemoCRUD-Lite/actions/workflows/main_blazordemocrud-lite.yml)

![BlazorDemoCRUD](https://repository-images.githubusercontent.com/593055304/693d4e94-295c-46bf-8473-c4baac737078)

## What & Why
This is a "Lite" version of the [BlazorDemoCRUD](https://github.com/shadowlings/BlazorDemoCRUD) project. This lite version has no external dependencies. No SQL DB. No Authentication/Authorization. Why? It is enables rapid prototyping and demoing. You could clone this project and start it up right now. The DB has been replaced with an "In Memory" database. The in memory DB will not persist data long term, so do not expect test data to last. This project still shows all the basic CRUD & search opertions.

## Demo
To demo this app, simply clone it and run it.

## Technologies
 - .NET 7
 - Blazor WASM
 - Web API
 - ~~MS SQL~~
 - ~~Auth0~~
 - GitHub Actions
 - Azure
 - Blazored Libraries
 - Bootstrap
 - Font Awesome

## Ignore Local Changes to AppSettings.json
Sensative configuration data, such as the DB connection strings, are kept in the  appsettings.json files. AppSettings exist in the API and Web projects. Depending on your situation, you may not want to check in these values to the repo. Use the following commands to ignore changes to the appsettings.json files:
 ```
 git update-index --assume-unchanged .\Server\appsettings.json
 ```
 To reverse the ignore, use these commands:
 ```
 git update-index --no-assume-unchanged .\Server\appsettings.json
 ```

## Setup CI/CD
Most applications need to be build and deployed. Outlined here are steps to setup automatted build and deployments (CI/CD)
1. [Microsoft outlines how to use Azure App Service Deployment Center to setup CI/CD with GitHub Actions](https://docs.microsoft.com/en-us/azure/app-service/deploy-github-actions?tabs=applevel#use-the-deployment-center). 
2. This project is a ["Hosted Blazor"](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly?view=aspnetcore-6.0#hosted-deployment-with-aspnet-core) application. When I deployed this application, I found that it wouldn't startup automatically. The default yaml workflow file, created by Azure, builds and publishes all projects in the solution. The consequence of this is that multiple .runtimeconfig files are created. Specifying that the build and publish should build the 'Server' project solves this issue. As a result, no special startup commands are necessary.

## Licensing
This project uses the 'Unlicense'.  It is a simple license - review it at your own leisure.

## Misc & Recommended Tools
1. [Azure](https://portal.azure.com)
2. [Namecheap Logo Maker](https://www.namecheap.com/logo-maker/)
3. [SSLS](https://www.ssls.com/)
4. [SVG Crop](https://svgcrop.com/)
