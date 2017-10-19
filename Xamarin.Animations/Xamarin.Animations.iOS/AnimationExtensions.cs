namespace Xamarin.Animations.iOS
{
    using System;
    using UIKit;
    using CoreGraphics;
    using CoreAnimation;

    /// <summary>
    /// A set of extensions for quickly animate a UIView with basic template animations (flip, rotate, scale, fade, zoom, ...).
    /// </summary>
    public static class AnimationExtensions
    {
        /// <summary>
        /// The default duration for all animations.
        /// </summary>
        public const double DefaultDuration = 0.30;

        /// <summary>
        /// The m34 for flip animations matrix.
        /// </summary>
        private static nfloat m34 = (nfloat)(-1 * 0.001);

        /// <summary>
        /// The minimum alpha.
        /// </summary>
        private static nfloat minAlpha = (nfloat)0.0f;

        /// <summary>
        /// The maximum alpha.
        /// </summary>
        private static nfloat maxAlpha = (nfloat)1.0f;

        /// <summary>
        /// The starting angle for rotation animation.
        /// </summary>
        private static double rotationAngle = 720;

        /// <summary>
        /// Fades the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Fade(this UIView view, AnimationTransition transition, double duration = DefaultDuration, Action onFinished = null)
        {
            view.Alpha = transition == AnimationTransition.In ? minAlpha : maxAlpha;
            view.Transform = CGAffineTransform.MakeIdentity();
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = transition == AnimationTransition.In ? maxAlpha : minAlpha;
                },
                onFinished
            );
        }

        /// <summary>
        /// Flips the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Flip(this UIView view, AnimationTransition transition, AnimationDirection direction, double duration = DefaultDuration, Action onFinished = null)
        {
            var isVertical = direction == AnimationDirection.Up || direction == AnimationDirection.Down;
            var isHorizontal = direction == AnimationDirection.Left || direction == AnimationDirection.Right;
            var isIn = transition == AnimationTransition.In;
            var isLtr = (transition == AnimationTransition.In && (direction == AnimationDirection.Down || direction == AnimationDirection.Left)) || (transition == AnimationTransition.Out && (direction == AnimationDirection.Up || direction == AnimationDirection.Right));

            var minTransform = CATransform3D.Identity;
            minTransform.m34 = m34;
            minTransform = minTransform.Rotate((nfloat)((isLtr ? 1 : -1) * Math.PI * 0.5), (nfloat)(isVertical ? 1.0f : 0.0f), (nfloat)(isHorizontal ? 1.0f : 0.0f), (nfloat)0.0f);
            var maxTransform = CATransform3D.Identity;
            maxTransform.m34 = m34;

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Layer.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Layer.AnchorPoint = new CGPoint((nfloat)0.5, (nfloat)0.5f);
                    view.Layer.Transform = isIn ? maxTransform : minTransform;
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                },
                onFinished
            );
        }

        /// <summary>
        /// Rotates the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Rotate(this UIView view, AnimationTransition transition, AnimationDirection direction, double duration = DefaultDuration, Action onFinished = null)
        {
            var minTransform = CGAffineTransform.MakeRotation((nfloat)((direction == AnimationDirection.Right ? -1 : 1) * rotationAngle));
            var maxTransform = CGAffineTransform.MakeRotation((nfloat)0.0);

            var isIn = transition == AnimationTransition.In;

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        /// <summary>
        /// Scales the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Scale(this UIView view, AnimationTransition transition, double duration = DefaultDuration, Action onFinished = null)
        {
            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeScale((nfloat)0.1, (nfloat)0.1);
            var maxTransform = CGAffineTransform.MakeScale((nfloat)1, (nfloat)1);

            var isIn = transition == AnimationTransition.In;

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        /// <summary>
        /// Slides the view over time.
        /// </summary>
        /// <param name="view">View.</param>
        /// <param name="transition">Transition.</param>
        /// <param name="direction">Direction.</param>
        /// <param name="duration">Duration.</param>
        /// <param name="onFinished">On finished.</param>
        public static void Slide(this UIView view, AnimationTransition transition, AnimationDirection direction, double duration = 0.3, Action onFinished = null)
        {
            var isIn = transition == AnimationTransition.In; 
            var isLtr = (transition == AnimationTransition.In && (direction == AnimationDirection.Down || direction == AnimationDirection.Left)) || (transition == AnimationTransition.Out && (direction == AnimationDirection.Up || direction == AnimationDirection.Right));
            var isVertical = direction == AnimationDirection.Up || direction == AnimationDirection.Down;
            var isHorizontal = direction == AnimationDirection.Left || direction == AnimationDirection.Right;

            var minAlpha = (nfloat)0.0f;
            var maxAlpha = (nfloat)1.0f;
            var minTransform = CGAffineTransform.MakeTranslation(
                                   (isHorizontal ? (isLtr ? 1 : -1) : 0) * view.Bounds.Width, 
                                   (isVertical ? (isLtr ? 1 : -1) : 0) * view.Bounds.Height);
            var maxTransform = CGAffineTransform.MakeIdentity();

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }

        public static void Zoom(this UIView view, AnimationTransition transition, double duration = 0.3, Action onFinished = null)
        {
            var isIn = transition == AnimationTransition.In;

            var minTransform = CGAffineTransform.MakeScale((nfloat)2.0, (nfloat)2.0);
            var maxTransform = CGAffineTransform.MakeScale((nfloat)1, (nfloat)1);

            view.Alpha = isIn ? minAlpha : maxAlpha;
            view.Transform = isIn ? minTransform : maxTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () =>
                {
                    view.Alpha = isIn ? maxAlpha : minAlpha;
                    view.Transform = isIn ? maxTransform : minTransform;
                },
                onFinished
            );
        }
    }
}

