![](Documentation/logo.png)

[![Build status](https://ci.appveyor.com/api/projects/status/8mtnmwdd4cxksy2m?svg=true)](https://ci.appveyor.com/project/aloisdeniel/xamarin-animations)

This cross-platform library tends to make view animation shareable and easier for common scenarios like fade or scale entrance animations.

![](Documentation/screen.gif)

## Installation

The library **will** be available soon on [NuGet](https://www.nuget.org/packages/Xamarin.Animations/).

To install Xamarin.Animations, run the following command in the Package Manager Console.

	PM> Install-Package Xam.Animations

## Usage

The package adds an `AnimateAsync()` extension method to `UIView`*(iOS)* and `View`*(Android)* and `UIElement`*(Windows)*.

To start an animation with an `IAnimation`.

```csharp
await view.AnimateAsync(Animations.FadeIn());
await view.AnimateAsync(Animations.FadeIn(duration: TimeSpan.FromSeconds(0.5f)));
await view.AnimateAsync(Animations.FadeIn(duration: TimeSpan.FromSeconds(0.5f), delay: TimeSpan.FromSeconds(0.2f)));
```

## Roadmap / ideas

* Adding UWP support
* Adding WPF support

## Contributions

Contributions are welcome! If you find a bug please report it and if you want a feature please report it.

If you want to contribute code please file an issue and create a branch off of the current dev branch and file a pull request.

## License

MIT © [Aloïs Deniel](http://aloisdeniel.github.io)