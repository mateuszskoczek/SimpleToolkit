# SimpleToolkit

SimpleToolkit is a set of helpers, models, controls, etc. used in my other C# projects.

## Contents

### Extensions

* StringExtensions
    - (static) CreateRandom - returns random string
    - Shuffle - returns shuffled string

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
