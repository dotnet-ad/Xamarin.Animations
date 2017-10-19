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
            throw new  System.NotImplementedException();
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
            throw new  System.NotImplementedException();
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
            throw new  System.NotImplementedException();
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
            throw new  System.NotImplementedException();
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
            throw new  System.NotImplementedException();
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
            throw new  System.NotImplementedException();
        }
    }

