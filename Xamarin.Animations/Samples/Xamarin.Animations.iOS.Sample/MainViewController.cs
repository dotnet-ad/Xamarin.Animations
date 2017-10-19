
using System;
using System.Drawing;

using Foundation;
using UIKit;
using System.Collections.Generic;

namespace Xamarin.Animations.iOS.Sample
{
    public partial class MainViewController : UIViewController
    {
        public MainViewController()
            : base("MainViewController", null)
        {

            this.ViewModel = new AnimationPickerViewModel();
        }

        public AnimationPickerViewModel ViewModel { get; private set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.animationPicker.Model = this.ViewModel;
        }

        partial void launchAnimation(Foundation.NSObject sender)
        {
            var row = this.animationPicker.SelectedRowInComponent(0);

            if (row >= 0 && row < AnimationPickerViewModel.Animations.Count)
            {
                AnimationPickerViewModel.Animations[(int)row].Item2(this.transitionSwitch.On, this.animatedView);
            }
        }

        /// <summary>
        /// View model of the controller.
        /// </summary>
        public class AnimationPickerViewModel : UIPickerViewModel
        {
            public static List<Tuple<string,Action<bool,UIView>>> Animations = new List<Tuple<string,Action<bool,UIView>>>()
            {
                new Tuple<string,Action<bool,UIView>>("Fade", (bool isIn, UIView view) => view.Fade(isIn ? AnimationTransition.In : AnimationTransition.Out)),
                new Tuple<string,Action<bool,UIView>>("SlideLeft", (bool isIn, UIView view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Left)),
                new Tuple<string,Action<bool,UIView>>("SlideRight", (bool isIn, UIView view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Right)),
                new Tuple<string,Action<bool,UIView>>("SlideUp", (bool isIn, UIView view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Up)),
                new Tuple<string,Action<bool,UIView>>("SlideDown", (bool isIn, UIView view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Down)),
                new Tuple<string,Action<bool,UIView>>("FlipLeft", (bool isIn, UIView view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Left)),
                new Tuple<string,Action<bool,UIView>>("FlipRight", (bool isIn, UIView view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Right)),
                new Tuple<string,Action<bool,UIView>>("FlipUp", (bool isIn, UIView view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Up)),
                new Tuple<string,Action<bool,UIView>>("FlipDown", (bool isIn, UIView view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Down)),
                new Tuple<string,Action<bool,UIView>>("Scale", (bool isIn, UIView view) => view.Scale(isIn ? AnimationTransition.In : AnimationTransition.Out)),
                new Tuple<string,Action<bool,UIView>>("Zoom", (bool isIn, UIView view) => view.Zoom(isIn ? AnimationTransition.In : AnimationTransition.Out)),
                new Tuple<string,Action<bool,UIView>>("RotateLeft", (bool isIn, UIView view) => view.Rotate(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Left)),
                new Tuple<string,Action<bool,UIView>>("RotateRight", (bool isIn, UIView view) => view.Rotate(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Right)),
            };

        
            public override nint GetComponentCount(UIPickerView pickerView)
            {
                return 1;
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                return Animations.Count;
            }

            public override string GetTitle(UIPickerView pickerView, nint row, nint component)
            {
                return Animations[(int)row].Item1;
            }
        }
    }
}

