using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Xamarin.Animations.Win.Universal.Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static List<Tuple<string, Action<bool, UIElement>>> Animations = new List<Tuple<string, Action<bool, UIElement>>>()
            {
                new Tuple<string,Action<bool,UIElement>>("Fade", (bool isIn, UIElement view) => view.Fade(isIn ? AnimationTransition.In : AnimationTransition.Out)),
                new Tuple<string,Action<bool,UIElement>>("SlideLeft", (bool isIn, UIElement view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Left)),
                new Tuple<string,Action<bool,UIElement>>("SlideRight", (bool isIn, UIElement view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Right)),
                new Tuple<string,Action<bool,UIElement>>("SlideUp", (bool isIn, UIElement view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Up)),
                new Tuple<string,Action<bool,UIElement>>("SlideDown", (bool isIn, UIElement view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Down)),
                new Tuple<string,Action<bool,UIElement>>("FlipLeft", (bool isIn, UIElement view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Left)),
                new Tuple<string,Action<bool,UIElement>>("FlipRight", (bool isIn, UIElement view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Right)),
                new Tuple<string,Action<bool,UIElement>>("FlipUp", (bool isIn, UIElement view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Up)),
                new Tuple<string,Action<bool,UIElement>>("FlipDown", (bool isIn, UIElement view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Down)),
                new Tuple<string,Action<bool,UIElement>>("Scale", (bool isIn, UIElement view) => view.Scale(isIn ? AnimationTransition.In : AnimationTransition.Out)),
                new Tuple<string,Action<bool,UIElement>>("Zoom", (bool isIn, UIElement view) => view.Zoom(isIn ? AnimationTransition.In : AnimationTransition.Out)),
                new Tuple<string,Action<bool,UIElement>>("RotateLeft", (bool isIn, UIElement view) => view.Rotate(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Left)),
                new Tuple<string,Action<bool,UIElement>>("RotateRight", (bool isIn, UIElement view) => view.Rotate(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Right)),
            };

        private int currentAnimation;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentAnimation = (this.currentAnimation + 1) % Animations.Count;
            this.animationLabel.Text = Animations[currentAnimation].Item1;
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentAnimation = this.currentAnimation == 0 ? Animations.Count - 1 : this.currentAnimation - 1;
            this.animationLabel.Text = Animations[currentAnimation].Item1;
        }

        private void launchButton_Click(object sender, RoutedEventArgs e)
        {
            var anim = Animations[currentAnimation];
            anim.Item2(this.transitionSwitch.IsChecked == null ? true : (bool)this.transitionSwitch.IsChecked, this.animatedView);
        }
    }
}
