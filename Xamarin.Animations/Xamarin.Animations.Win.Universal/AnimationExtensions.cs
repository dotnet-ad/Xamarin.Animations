using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace Xamarin.Animations.Win.Universal
{
    public static class AnimationExtensions
    {
        /// <summary>
        /// Fades the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Fade(this UIElement view, AnimationTransition transition, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            view.RenderTransform = null;
            view.Projection = null;

            CreateStoryboard(view, duration, transition).Begin();
        }

        /// <summary>
        /// Flips the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Flip(this UIElement view, AnimationTransition transition, AnimationDirection direction, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            double minTransform = 0;
            double maxTransform = 0;
            var isIn = transition == AnimationTransition.In;
            var isHorizontal = direction == AnimationDirection.Left || direction == AnimationDirection.Right;

            if (direction == AnimationDirection.Right || direction == AnimationDirection.Up)
            {
                minTransform = isIn ? 90 : 270;
                maxTransform = isIn ? 0 : 360;

            }
            else
            {
                minTransform = isIn ? -90 : 440;
                maxTransform = isIn ? 0 : 360;
            }

            var transform = new PlaneProjection();
            view.RenderTransform = null;
            view.Projection = transform;

            CreateStoryboard(view, duration, transition)
                .CreateDoubleAnimation(transform, isHorizontal ? "RotationY" : "RotationX", minTransform, maxTransform, transition)
                .Begin();
        }

        /// <summary>
        /// Rotates the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Rotate(this UIElement view, AnimationTransition transition, AnimationDirection direction, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            var transform = new RotateTransform();
            view.Projection = null;
            view.RenderTransform = transform;
            view.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);

            CreateStoryboard(view, duration, transition)
                .CreateDoubleAnimation(transform, "Angle", (direction == AnimationDirection.Right ? -1 : 1) * AnimationConstants.RotationAngle / 3, 0, transition)
                .Begin();
        }

        /// <summary>
        /// Scales the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Scale(this UIElement view, AnimationTransition transition, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            var transform = new ScaleTransform();
            view.Projection = null;
            view.RenderTransform = transform;
            view.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);

            CreateStoryboard(view, duration, transition)
                .CreateDoubleAnimation(transform, "ScaleX", AnimationConstants.MinScale, AnimationConstants.MaxScale, transition)
                .CreateDoubleAnimation(transform, "ScaleY", AnimationConstants.MinScale, AnimationConstants.MaxScale, transition)
                .Begin();

        }

        /// <summary>
        /// Slides the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Slide(this UIElement view, AnimationTransition transition, AnimationDirection direction, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            var isIn = transition == AnimationTransition.In;
            var isLtr = (transition == AnimationTransition.In && (direction == AnimationDirection.Down || direction == AnimationDirection.Left)) || (transition == AnimationTransition.Out && (direction == AnimationDirection.Up || direction == AnimationDirection.Right));
            var isVertical = direction == AnimationDirection.Up || direction == AnimationDirection.Down;
            var isHorizontal = direction == AnimationDirection.Left || direction == AnimationDirection.Right;

            var minTransformX = (isHorizontal ? (isLtr ? 1 : -1) : 0) * view.RenderSize.Width;
            var minTransformY = (isVertical ? (!isLtr ? 1 : -1) : 0) * view.RenderSize.Height;
            var maxTransformX = 0;
            var maxTransformY = 0;

            var transform = new TranslateTransform();
            view.Projection = null;
            view.RenderTransform = transform;
            view.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);

            CreateStoryboard(view, duration, transition)
                .CreateDoubleAnimation(transform, "X", minTransformX, maxTransformX, transition)
                .CreateDoubleAnimation(transform, "Y", minTransformY, maxTransformY, transition)
                .Begin();
           
        }

        /// <summary>
        /// Zooms the specified view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Zoom(this UIElement view, AnimationTransition transition, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            var transform = new ScaleTransform();
            view.Projection = null;
            view.RenderTransform = transform;
            view.RenderTransformOrigin = new Windows.Foundation.Point(0.5, 0.5);

            CreateStoryboard(view, duration, transition)
                .CreateDoubleAnimation(transform, "ScaleX", AnimationConstants.MinZoom, AnimationConstants.MaxZoom, transition)
                .CreateDoubleAnimation(transform, "ScaleY", AnimationConstants.MinZoom, AnimationConstants.MaxZoom, transition)
                .Begin();
        }

        private static Storyboard CreateStoryboard(DependencyObject element, double duration, AnimationTransition transition)
        {
            Storyboard sb = new Storyboard()
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
            };

            sb.CreateDoubleAnimation(element, "Opacity", AnimationConstants.MinAlpha, AnimationConstants.MaxAlpha, transition);

            return sb;
        }

        private static Storyboard CreateDoubleAnimation(this Storyboard sb, DependencyObject element, string name, double from, double to, AnimationTransition transition)
        {
            var min = (float)(transition == AnimationTransition.In ? from : to);
            var max = (float)(transition == AnimationTransition.In ? to : from);

            DoubleAnimation anim = new DoubleAnimation();
            anim.From = min;
            anim.To = max;
            anim.Duration = sb.Duration;
            anim.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseInOut };
            Storyboard.SetTarget(anim, element);
            Storyboard.SetTargetProperty(anim, name);
            sb.Children.Add(anim);

            return sb;
        }
    }
}
