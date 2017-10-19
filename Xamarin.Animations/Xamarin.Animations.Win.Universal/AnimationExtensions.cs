using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

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
           
        }
    }
}
