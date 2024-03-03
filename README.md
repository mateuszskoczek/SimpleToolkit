# SimpleToolkit

SimpleToolkit is a set of helpers, models, controls, etc. used in my other C# projects.

## Status

| Project | NuGet Gallery |
| ------- | ------------- |
| Extensions | [![NuGet version (SimpleToolkit.Extensions)](https://img.shields.io/nuget/v/SimpleToolkit.Extensions.svg?style=flat-square)](https://www.nuget.org/packages/SimpleToolkit.Extensions/) |
| Attributes | [![NuGet version (SimpleToolkit.Attributes)](https://img.shields.io/nuget/v/SimpleToolkit.Attributes.svg?style=flat-square)](https://www.nuget.org/packages/SimpleToolkit.Attributes/) |
| MVVM | [![NuGet version (SimpleToolkit.MVVM)](https://img.shields.io/nuget/v/SimpleToolkit.MVVM.svg?style=flat-square)](https://www.nuget.org/packages/SimpleToolkit.MVVM/) |
| UI.Models | [![NuGet version (SimpleToolkit.UI.Models)](https://img.shields.io/nuget/v/SimpleToolkit.UI.Models.svg?style=flat-square)](https://www.nuget.org/packages/SimpleToolkit.UI.Models/) |
| UI.WinUI.Behaviors | [![NuGet version (SimpleToolkit.UI.WinUI.Behaviors)](https://img.shields.io/nuget/v/SimpleToolkit.UI.WinUI.Behaviors.svg?style=flat-square)](https://www.nuget.org/packages/SimpleToolkit.UI.WinUI.Behaviors/) |
| UI.WinUI.Converters | [![NuGet version (SimpleToolkit.UI.WinUI.Converters)](https://img.shields.io/nuget/v/SimpleToolkit.UI.WinUI.Converters.svg?style=flat-square)](https://www.nuget.org/packages/SimpleToolkit.UI.WinUI.Converters/) |
| UI.WinUI.Controls | [![NuGet version (SimpleToolkit.UI.WinUI.Controls)](https://img.shields.io/nuget/v/SimpleToolkit.UI.WinUI.Controls.svg?style=flat-square)](https://www.nuget.org/packages/SimpleToolkit.UI.WinUI.Controls/) |

## Contents

### Extensions

* StringExtensions
    - (static) CreateRandom - returns random string
    - Shuffle - returns shuffled string
* HttpClientExtensions
    - DownloadAsync - allows to track progress of downloading data
* StreamExtensions
    - CopyToAsync - allows to track progress of copying data

### Attributes

* RequiresClaimAttribute - returns Forbidden result, when claim is not present

### MVVM

* ObservableKeyValuePair - Observable version of KeyValuePair
* ObservableDictionary - Observable version of Dictionary

### UI.Models

* NavigationViewItem - model which can be used to implement NavigationViewService-less navigation in MVVM

### UI.WinUI.Behaviors

* EventToCommandBehavior - allows to bind parametrized command to any event

### UI.WinUI.Converters

* ObjectToIntConverter - converts any object to int (e.g. enums)
* ObjectToStringConverter - converts any object to string

### UI.WinUI.Controls

* TimeSpanControl - allows to select TimeSpan

![alt text](https://raw.githubusercontent.com/mateuszskoczek/SimpleToolkit/master/.github/images/timespancontrol.png)
