namespace Xamarin.Animations.Droid
{
    using System;
    using Android.Views;

    /// <summary>
    /// A set of extensions for quickly animate a UIView with basic template animations (flip, rotate, scale, fade, zoom, ...).
    /// </summary>
    public static class AnimationExtensions
    {
        /// <summary>
        /// Fades the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Fade(this View view, AnimationTransition transition, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            var isIn = transition == AnimationTransition.In;

            view.Alpha = (float)(isIn ? AnimationConstants.MinAlpha : AnimationConstants.MaxAlpha);
            view.ScaleX = view.ScaleY = 1;
            view.TranslationX = view.TranslationY = 0;

            view.Animate()
                .SetDuration((int)(duration * 1000))
                .Alpha((float)(isIn ? AnimationConstants.MaxAlpha : AnimationConstants.MinAlpha));
        }

        /// <summary>
        /// Flips the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Flip(this View view, AnimationTransition transition, AnimationDirection direction, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            
        }

        /// <summary>
        /// Rotates the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Rotate(this View view, AnimationTransition transition, AnimationDirection direction, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            var isIn = transition == AnimationTransition.In;

            var minAngle = (float)((direction == AnimationDirection.Right ? -1 : 1) * AnimationConstants.RotationAngle);
            var maxAngle = 0.0f;

            view.Alpha = (float)(isIn ? AnimationConstants.MinAlpha : AnimationConstants.MaxAlpha);
            view.Rotation = (float)((isIn ? minAngle : maxAngle) / Math.PI);
            view.ScaleX = view.ScaleY = 1;
            view.TranslationX = view.TranslationY = 0;

            view.Animate()
                .SetDuration((int)(duration * 1000))
                .Alpha((float)(isIn ? AnimationConstants.MaxAlpha : AnimationConstants.MinAlpha))
                .Rotation((float)((isIn ? maxAngle : minAngle) / Math.PI));
        }

        /// <summary>
        /// Scales the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Scale(this View view, AnimationTransition transition, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            var isIn = transition == AnimationTransition.In;

            view.Alpha = (float)(isIn ? AnimationConstants.MinAlpha : AnimationConstants.MaxAlpha);
            view.ScaleX = (float)(isIn ? AnimationConstants.MinScale : AnimationConstants.MaxScale);
            view.ScaleY = (float)(isIn ? AnimationConstants.MinScale : AnimationConstants.MaxScale);
            view.TranslationX = view.TranslationY = 0;

            view.Animate()
                .SetDuration((int)(duration * 1000))
                .Alpha((float)(isIn ? AnimationConstants.MaxAlpha : AnimationConstants.MinAlpha))
                .ScaleX((float)(isIn ? AnimationConstants.MaxScale : AnimationConstants.MinScale))
                .ScaleY((float)(isIn ? AnimationConstants.MaxScale : AnimationConstants.MinScale));
        }

        /// <summary>
        /// Slides the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Slide(this View view, AnimationTransition transition, AnimationDirection direction, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            var isIn = transition == AnimationTransition.In;
            var isLtr = (transition == AnimationTransition.In && (direction == AnimationDirection.Down || direction == AnimationDirection.Left)) || (transition == AnimationTransition.Out && (direction == AnimationDirection.Up || direction == AnimationDirection.Right));
            var isVertical = direction == AnimationDirection.Up || direction == AnimationDirection.Down;
            var isHorizontal = direction == AnimationDirection.Left || direction == AnimationDirection.Right;

            var minTransformX = (isHorizontal ? (isLtr ? 1 : -1) : 0) * view.Width;
            var minTransformY = (isVertical ? (!isLtr ? 1 : -1) : 0) * view.Height;
            var maxTransformX = 0;
            var maxTransformY = 0;

            view.Alpha = (float)(isIn ? AnimationConstants.MinAlpha : AnimationConstants.MaxAlpha);
            view.TranslationX = isIn ? minTransformX : maxTransformX;
            view.TranslationY = isIn ? minTransformY : maxTransformY;
            view.ScaleX = view.ScaleY = 1;

             view.Animate()
                .SetDuration((int)(duration * 1000))
                .Alpha((float)(isIn ? AnimationConstants.MaxAlpha : AnimationConstants.MinAlpha))
                .TranslationX(isIn ? maxTransformX : minTransformX)
                .TranslationY(isIn ? maxTransformY : minTransformY);
        }

        /// <summary>
        /// Zooms the specified view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Zoom(this View view, AnimationTransition transition, double duration = AnimationConstants.DefaultDuration, Action onFinished = null)
        {
            var isIn = transition == AnimationTransition.In;

            view.Alpha = (float)(isIn ? AnimationConstants.MinAlpha : AnimationConstants.MaxAlpha);
            view.ScaleX = (float)(isIn ? AnimationConstants.MinZoom : AnimationConstants.MaxZoom);
            view.ScaleY = (float)(isIn ? AnimationConstants.MinZoom : AnimationConstants.MaxZoom);

            view.Animate()
                .SetDuration((int)(duration * 1000))
                .Alpha((float)(isIn ? AnimationConstants.MaxAlpha : AnimationConstants.MinAlpha))
                .ScaleX((float)(isIn ? AnimationConstants.MaxZoom : AnimationConstants.MinZoom))
                .ScaleY((float)(isIn ? AnimationConstants.MaxZoom : AnimationConstants.MinZoom));
        }
    }
}
