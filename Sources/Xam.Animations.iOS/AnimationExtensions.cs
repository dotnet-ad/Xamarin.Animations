namespace Xam.Animations
{
    using System;
    using System.Threading.Tasks;
    using CoreGraphics;
    using UIKit;

    public static class AnimationExtensions
    {
        internal static CGAffineTransform ToNative(this Transform transform, CGSize size)
        {
            //Weird behaviour with 0.
            var scaleX = Math.Max(0.001f, transform.ScaleX);
            var scaleY = Math.Max(0.001f, transform.ScaleY);

            var result = CGAffineTransform.MakeIdentity();
            result.Scale(scaleX, scaleY);
            result.Rotate(transform.Rotation);
            result.Translate(transform.TranslateX * size.Width, transform.TranslateY * size.Height);
            return result;
        }

        internal static UIViewAnimationOptions ToNative(this Curve curve)
        {
            switch (curve)
            {
                case Curve.EaseIn:
                    return UIViewAnimationOptions.CurveEaseIn;
                case Curve.EaseOut:
                    return UIViewAnimationOptions.CurveEaseOut;
                default:
                    throw new InvalidOperationException();
            }
        }

        public static async Task AnimateAsync(this UIView view, IAnimation animation)
        {
            if (animation is TransformAnimation transformAnimation)
            {
                var source = new TaskCompletionSource<bool>();

                view.Alpha = transformAnimation.From.Opacity;
                view.Transform = transformAnimation.From.ToNative(view.Bounds.Size);

                UIView.Animate(animation.Duration.TotalSeconds, animation.Delay.TotalSeconds, transformAnimation.Curve.ToNative(), () =>
                {
                    view.Alpha = transformAnimation.To.Opacity;
                    view.Transform = transformAnimation.To.ToNative(view.Bounds.Size);
                },() => source.SetResult(true));
                
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
