namespace Xam.Animations
{
    using System;
    using System.Threading.Tasks;
    using Android.Views;
    using Android.Views.Animations;

    public static class AnimationExtensions
    {
        internal static IInterpolator ToNative(this Curve curve)
        {
            switch (curve)
            {
                case Curve.EaseIn:
                    return new RelayInterpolator(t => t * t);
                case Curve.EaseOut:
                    return new RelayInterpolator(t => t * (2 - t));
                default:
                    throw new InvalidOperationException();
            }
        }

        public static async Task AnimateAsync(this View view, IAnimation animation)
        {
            if (animation is TransformAnimation transformAnimation)
            {
                var source = new TaskCompletionSource<bool>();

                view.Alpha = transformAnimation.From.Opacity;
                view.Rotation = transformAnimation.From.Rotation;
                view.ScaleX = transformAnimation.From.ScaleX;
                view.ScaleY = transformAnimation.From.ScaleY;
                view.TranslationX = transformAnimation.From.TranslateX * view.Width;
                view.TranslationY = transformAnimation.From.TranslateY * view.Height;

                var animator = view.Animate()
                    .SetInterpolator(transformAnimation.Curve.ToNative())
                    .WithEndAction(new Java.Lang.Runnable(() => source.SetResult(true)))
                    .SetStartDelay((long)animation.Delay.TotalMilliseconds)
                    .SetDuration((long)animation.Duration.TotalMilliseconds)
                    .TranslationX(transformAnimation.From.TranslateX * view.Width)
                    .TranslationY(transformAnimation.From.TranslateY * view.Height)
                    .ScaleX(transformAnimation.From.ScaleX)
                    .ScaleY(transformAnimation.From.ScaleY)
                    .Alpha(transformAnimation.From.Opacity)
                    .Rotation(transformAnimation.From.Rotation);

                animator.Start();
                
                await source.Task;
            }
            else if (animation is SequenceAnimation sequenceAnimation)
            {
                foreach (var childAnimation in sequenceAnimation)
                {
                    await view.AnimateAsync(childAnimation);
                }
            }
        }
    }
}
