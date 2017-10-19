using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Xamarin.Animations.Droid;

namespace Xamarin.Animations.Android.Sample
{
    [Activity(Label = "Xamarin.Animations.Android.Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static List<Tuple<string, Action<bool, View>>> Animations = new List<Tuple<string, Action<bool, View>>>()
            {
                new Tuple<string,Action<bool,View>>("Fade", (bool isIn, View view) => view.Fade(isIn ? AnimationTransition.In : AnimationTransition.Out)),
                new Tuple<string,Action<bool,View>>("SlideLeft", (bool isIn, View view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Left)),
                new Tuple<string,Action<bool,View>>("SlideRight", (bool isIn, View view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Right)),
                new Tuple<string,Action<bool,View>>("SlideUp", (bool isIn, View view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Up)),
                new Tuple<string,Action<bool,View>>("SlideDown", (bool isIn, View view) => view.Slide(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Down)),
                new Tuple<string,Action<bool,View>>("FlipLeft", (bool isIn, View view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Left)),
                new Tuple<string,Action<bool,View>>("FlipRight", (bool isIn, View view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Right)),
                new Tuple<string,Action<bool,View>>("FlipUp", (bool isIn, View view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Up)),
                new Tuple<string,Action<bool,View>>("FlipDown", (bool isIn, View view) => view.Flip(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Down)),
                new Tuple<string,Action<bool,View>>("Scale", (bool isIn, View view) => view.Scale(isIn ? AnimationTransition.In : AnimationTransition.Out)),
                new Tuple<string,Action<bool,View>>("Zoom", (bool isIn, View view) => view.Zoom(isIn ? AnimationTransition.In : AnimationTransition.Out)),
                new Tuple<string,Action<bool,View>>("RotateLeft", (bool isIn, View view) => view.Rotate(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Left)),
                new Tuple<string,Action<bool,View>>("RotateRight", (bool isIn, View view) => view.Rotate(isIn ? AnimationTransition.In : AnimationTransition.Out, AnimationDirection.Right)),
            };

        private int currentAnimation;


        private ToggleButton transitionSwitch;
        private View animatedView;
        private TextView animationLabel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Button clicks
            FindViewById<Button>(Resource.Id.launchButton).Click += Launch;
            FindViewById<Button>(Resource.Id.nextButton).Click += Next;
            FindViewById<Button>(Resource.Id.previousButton).Click += Previous;

            //Views
            this.transitionSwitch = FindViewById<ToggleButton>(Resource.Id.transitionButton);
            this.animatedView = FindViewById<View>(Resource.Id.animatedView);
            this.animationLabel = FindViewById<TextView>(Resource.Id.animationLabel);
        }

        private void Launch(object sender, EventArgs e)
        {
            var anim = Animations[currentAnimation];
            anim.Item2(this.transitionSwitch.Checked, this.animatedView);
            
        }

        private void Next(object sender, EventArgs e)
        {
            this.currentAnimation = (this.currentAnimation + 1) % Animations.Count;
            this.animationLabel.Text = Animations[currentAnimation].Item1;
        }

        private void Previous(object sender, EventArgs e)
        {
            this.currentAnimation = this.currentAnimation == 0 ? Animations.Count - 1 : this.currentAnimation - 1;
            this.animationLabel.Text = Animations[currentAnimation].Item1;
        }
    }
}

