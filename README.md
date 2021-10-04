[![Build Status](https://img.shields.io/github/workflow/status/carlosga/blatternfly/Build%20&%20Tests?color=007ec6&logo=github&style=for-the-badge)](https://github.com/carlosga/blatternfly/actions/workflows/dotnet.yml)
[![GitHub last commit](https://img.shields.io/github/last-commit/carlosga/blatternfly?color=007ec6&style=for-the-badge&logo=github)](https://github.com/carlosga/blatternfly)
[![GitHub](https://img.shields.io/github/license/carlosga/blatternfly?color=007ec6&style=for-the-badge&logo=github)](https://github.com/carlosga/blatternfly/blob/master/LICENSE)
[![Nuget version](https://img.shields.io/nuget/v/Blatternfly?color=007ec6&label=nuget%20version&style=for-the-badge&logo=nuget)](https://www.nuget.org/packages/Blatternfly/)
[![Nuget downloads](https://img.shields.io/nuget/dt/Blatternfly?color=007ec6&label=nuget%20downloads&style=for-the-badge&logo=nuget)](https://www.nuget.org/packages/Blatternfly/)

<!-- PROJECT LOGO -->
## Blatternfly

[View demo](https://carlosga.github.io/blatternfly)

<!-- ABOUT THE PROJECT -->
## About The Project

**Blazor learning project.** Blatternfly is a [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) implementation of [PatternFly](https://www.patternfly.org/v4/).

### Built With

* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor). Some parts of the form and input base components has been copied over from Blazor source code.
* [PatternFly](https://www.patternfly.org/v4/).

<!-- GETTING STARTED -->

## Getting started

### Prerequisites

* .NET 5.0

### Imports

Add the following to `_Imports.razor`

```razor
@using Blatternfly
@using Blatternfly.Components
@using Blatternfly.Layouts
```

### Patternfly CSS

Add the following to `index.html`

```html
<link href="_content/Blatternfly/patternfly.css" rel="stylesheet" />
<link href="_content/Blatternfly/patternfly-addons.css" rel="stylesheet" />
```

See also the [getting started](https://www.patternfly.org/v4/get-started/develop#htmlcss) section on the PatternFly website for more details.

### Configuration

Example of Blatternfly configuration in `Program.cs`

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.AddBlatternfly();

var webhost = builder.Build();

await webhost.UseBlatternfly();
await webhost.RunAsync();
```

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements
* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor).
* [PatternFly](https://www.patternfly.org/v4/).
* [CssBuilder](https://github.com/EdCharbeneau/CssBuilder).
* [focus-trap](https://github.com/focus-trap/focus-trap).
* [tabbable](https://github.com/focus-trap/tabbable).
* [Best Readme Template](https://github.com/othneildrew/Best-README-Template).

