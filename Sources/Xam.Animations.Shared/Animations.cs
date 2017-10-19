namespace Xam.Animations
{
    using System;

    /// <summary>
    /// Common animations.
    /// </summary>
    public static class Animations
    {
        public static readonly TimeSpan DefaultDuration = TimeSpan.FromMilliseconds(300);

        public static readonly TimeSpan DefaultDelay = TimeSpan.FromMilliseconds(0);

        public static TransformAnimation FadeIn(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(opacity: 0),
                new Transform(opacity: 1),
                Curve.EaseOut);
        
        public static TransformAnimation FadeOut(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(opacity: 1),
                new Transform(opacity: 0),
                Curve.EaseIn);

        public static TransformAnimation ScaleIn(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(scaleX: 0, scaleY: 0, opacity: 0),
                new Transform(scaleX: 1, scaleY: 1, opacity: 1),
                Curve.EaseOut);

        public static TransformAnimation ScaleOut(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(scaleX: 1, scaleY: 1, opacity: 1),
                new Transform(scaleX: 0, scaleY: 0, opacity: 0),
                Curve.EaseIn);

        public static TransformAnimation ScaleInFromTop(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(scaleY: 0, opacity: 0, translateY: -0.5f),
                new Transform(scaleY: 1, opacity: 1, translateY: 0),
                Curve.EaseOut);

        public static TransformAnimation ScaleOutFromTop(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(scaleY: 1, opacity: 1, translateY: 0),
                new Transform(scaleY: 0, opacity: 0, translateY: -0.5f),
                Curve.EaseOut);

        public static TransformAnimation ScaleInFromBottom(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(scaleY: 0, opacity: 0, translateY: 0.5f),
                new Transform(scaleY: 1, opacity: 1, translateY: 0),
                Curve.EaseOut);

        public static TransformAnimation ScaleOutFromBottom(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(scaleY: 1, opacity: 1, translateY: 0),
                new Transform(scaleY: 0, opacity: 0, translateY: 0.5f),
                Curve.EaseOut);

        public static TransformAnimation ScaleInFromLeft(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(scaleX: 0, opacity: 0, translateX: -0.5f),
                new Transform(scaleX: 1, opacity: 1, translateX: 0),
                Curve.EaseOut);

        public static TransformAnimation ScaleOutFromLeft(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(scaleX: 1, opacity: 1, translateX: 0),
                new Transform(scaleX: 0, opacity: 0, translateX: -0.5f),
                Curve.EaseOut);

        public static TransformAnimation ScaleInFromRight(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(scaleX: 0, opacity: 0, translateX: 0.5f),
                new Transform(scaleX: 1, opacity: 1, translateX: 0),
                Curve.EaseOut);

        public static TransformAnimation ScaleOutFromRight(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(scaleX: 1, opacity: 1, translateX: 0),
                new Transform(scaleX: 0, opacity: 0, translateX: 0.5f),
                Curve.EaseOut);
        
        public static TransformAnimation SlideUpIn(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(translateY: 1, opacity: 0),
                new Transform(translateY: 0, opacity: 1),
                Curve.EaseOut);

        public static TransformAnimation SlideUpOut(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(translateY: 0, opacity: 1),
                new Transform(translateY: 1, opacity: 0),
                Curve.EaseIn);

        public static TransformAnimation SlideDownIn(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(translateY: -1, opacity: 0),
                new Transform(translateY: 0, opacity: 1),
                Curve.EaseOut);

        public static TransformAnimation SlideDownOut(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(translateY: 0, opacity: 1),
                new Transform(translateY: -1, opacity: 0),
                Curve.EaseIn);

        public static TransformAnimation SlideRightIn(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(translateX: -1, opacity: 0),
                new Transform(translateX: 0, opacity: 1),
                Curve.EaseOut);

        public static TransformAnimation SlideRightOut(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(translateX: 0, opacity: 1),
                new Transform(translateX: -1, opacity: 0),
                Curve.EaseIn);

        public static TransformAnimation SlideLeftIn(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(translateX: 1, opacity: 0),
                new Transform(translateX: 0, opacity: 1),
                Curve.EaseOut);

        public static TransformAnimation SlideLeftOut(TimeSpan? duration = null, TimeSpan? delay = null) => new TransformAnimation(
                delay ?? DefaultDelay,
                duration ?? DefaultDuration,
                new Transform(translateX: 0, opacity: 1),
                new Transform(translateX: 1, opacity: 0),
                Curve.EaseIn);
    
    }
}
