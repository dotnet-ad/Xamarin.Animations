// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Xamarin.Animations.iOS.Sample
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		UIKit.UIView animatedView { get; set; }

		[Outlet]
		UIKit.UIPickerView animationPicker { get; set; }

		[Outlet]
		UIKit.UISwitch transitionSwitch { get; set; }

		[Action ("launchAnimation:")]
		partial void launchAnimation (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (animatedView != null) {
				animatedView.Dispose ();
				animatedView = null;
			}

			if (transitionSwitch != null) {
				transitionSwitch.Dispose ();
				transitionSwitch = null;
			}

			if (animationPicker != null) {
				animationPicker.Dispose ();
				animationPicker = null;
			}
		}
	}
}
