# Middleware_Sample
## Description
The Middleware_Sample application is a basic c# middleware implementation that checks the configuration file to determine if technical work is underway and prohibits API access is so. The application is developed on the .NET framework.

>The project is implemented using the IOptions pattern to work with the  configuration file. For more information about this pattern, see the Used links section.

## Technical requirements

If in _appsettings.json_ configuration file IsTechnicalWorkInProgress is marked as true, this means that some technical work is being carried out on the service and access to the Web API is denied.



## Installation
To run the AttributesSample application, follow these steps:

1. Clone the repository: `git clone https://https://github.com/BorisMinin/Middleware_Sample.git`
2. Open the solution in Visual Studio.
3. Build the solution.
4. Run the program.

## Usage
To use the Web API, you need to try out several scenarios:
1. In the _appsettings.json_ configuration file specify the _true_ value for the IsTechnicalWorkInProgress key, which will signal the ongoing technical work on the service. In this case, when you start the project, you will receive an error message
2. In the _appsettings.json_ configuration file specify the _false_ value for the IsTechnicalWorkInProgress key, which will signal that no technical work is currently being carried out on the service. In this case, when you start the project, swagger will be launched and you will be able to use endpoints

First scenario: 

![First scenario](https://github.com/BorisMinin/Middleware_Sample/assets/32355926/69bc5aa5-9d2b-437b-b576-9d58b9c5f005)

Second scenario:

![Second scenario](https://github.com/BorisMinin/Middleware_Sample/assets/32355926/a387493b-fc29-48eb-a5d6-509a940af6f2)


_appsettings.json_ configuration file:

```JSON
"TechnicalWork": {
  "IsTechnicalWorkInProgress": true
}
```

## How it works
To create a custom middleware, click Add->Class->Middleware Class.
The implementation of any technical requirements using middleware is performed in the Invoke method.

```csharp
    public async Task Invoke(HttpContext httpContext)
    {
        if (_technicalWorkConfiguration.IsTechnicalWorkInProgress)
        {
            httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            await httpContext.Response.WriteAsync("Technical work in progress. Access is prohibited.");
            return;
        }

        await _next(httpContext);
    }
```
To learn more about creating custom middleware, see the Used links section

## Used links
**Create custom middleware:** `https://www.tutorialsteacher.com/core/how-to-add-custom-middleware-aspnet-core`
**IOptions pattern** `https://andrewlock.net/how-to-use-the-ioptions-pattern-for-configuration-in-asp-net-core-rc2/`
