# HTTP-Request-Service ![.NET Core](https://github.com/leo-oliveira-eng/HTTP-Request-Service/workflows/.NET%20Core/badge.svg) [![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md) [![NuGet](https://img.shields.io/nuget/vpre/Http.Request.Service)](https://www.nuget.org/packages/Http.Request.Service/)

Package that encapsulates methods to help REST communication between HTTP services.


## Installation

HTTP.Request.Service is available on [NuGet](https://www.nuget.org/packages/Http.Request.Service/).  You can find the raw NuGet file [here](https://www.nuget.org/api/v2/package/Http.Request.Service/1.0.0-preview-1) or install it by the commands below depending on your platform:

 - Package Manager
```
pm> Install-Package Http.Request.Service -Version 1.0.0-preview-1
```

 - via the .NET Core CLI:
```
> dotnet add package Http.Request.Service --version 1.0.0-preview-1
```

 - PackageReference
```
<PackageReference Include="Http.Request.Service" Version="1.0.0-preview-1" />
```

 - PaketCLI
```
> paket add Http.Request.Service --version 1.0.0-preview-1
```

## How to Use

Implement base class for HTTP service

```csharp

public abstract class ServiceConnector
{
    protected internal IHttpService HttpService { get; }

    protected internal string ResourceName { get; }

    protected HttpRequest HttpRequest { get; private set; }

    public ServiceConnector(IHttpService httpService, string resourceName)
    {
        HttpService = httpService ?? throw new ArgumentNullException($"{httpService}. Adicione o 'app.MakeMagicConnector();' na 'startup.css'.");
        ResourceName = resourceName;
    }

    public void SetHttpRequest(HttpRequest httpRequest)
        => HttpRequest = httpRequest ?? throw new ArgumentNullException(nameof(httpRequest));
}

```

Then you can implement your service inheriting from the base service class.

```csharp

public class YourServiceConnector : ServiceConnector, IYourServiceConnector
{
    public YourServiceConnector(IHttpService httpService) : base(httpService, "route") { }

...

    public async Task<Response<AnyResponseMessage>> CreateAsync(AnyRequestMessage requestMessage, string httpClientConfigurationName)
       => await HttpService.PostAsync<AnyRequestMessage, AnyResponseMessage>(ResourceName, requestMessage, httpClientConfigurationName);
       
...

}

```

