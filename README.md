# Xamarin.Animations

Those libraries tends to make view animation easier for common scenarios like fade or scale entrance animations.

![](screen.gif)

## Installation

The library **will** be available soon on [NuGet](https://www.nuget.org/packages/Xamarin.Animations/).

To install Xamarin.Animations, run the following command in the Package Manager Console.

	PM> Install-Package Xamarin.Animations

## Usage

The animations are a set of extensions for `UIView`*(iOS)* and `View`*(Android)*.

The extension methods can take these parameters :

* `AnimationDirection` `direction` : indicates the direction for the animation. If you choose `Left` it will generally move from **right to left**.
* `AnimationTransition` `transition` : indicates wether it is an entrance or an exit animation.
* `double` `duration` : the duration of the animation in seconds *(optional - default 0.3s)*
* `Action` `onFinished` : a completion handler *(optional)*


To start an animation, simply call one of the extensions on your view.

	view.Fade(AnimationTransition.In);
	
	view.Zoom(AnimationTransition.In, 0.5);
	
	view.Scale(AnimationTransition.Out, 0.2, () => { /* ... */ });
	
	view.Flip(AnimationTransition.In, AnimationDirection.Left);
	
	view.Slide(AnimationTransition.Out, AnimationDirection.Down, 0.4);
	
	view.Rotate(AnimationTransition.Out, AnimationDirection.Left, 0.2, () => { /* ... */ });

## Roadmap / ideas

* Adding WindowsPhone/Store support
* Adding Mac support
* Adding WPF support

## Copyright and license

Code and documentation copyright 2014-2015 Aloïs Deniel released under the MIT license.