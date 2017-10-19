namespace Xam.Animations
{
    using System;
    using System.Threading.Tasks;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Animation;

    public static class AnimationExtensions
    {
        internal static EasingFunctionBase ToNative(this Curve curve)
        {
            switch (curve)
            {
                case Curve.EaseIn:
                    return new QuadraticEase() { EasingMode = EasingMode.EaseIn };
                case Curve.EaseOut:
                    return new QuadraticEase() { EasingMode = EasingMode.EaseOut };
                default:
                    throw new InvalidOperationException();
            }
        }

        internal static Storyboard AddDoubleAnimation(this Storyboard sb, DependencyObject element, string name, double from, double to, EasingFunctionBase curve)
        {
            var anim = new DoubleAnimation();
            anim.From = from;
            anim.To = to;
            anim.Duration = sb.Duration;
            anim.EasingFunction = curve;
            Storyboard.SetTarget(anim, element);
            Storyboard.SetTargetProperty(anim, name);
            sb.Children.Add(anim);

            return sb;
        }

        public static async Task AnimateAsync(this UIElement view, IAnimation animation)
        {
            if (animation is TransformAnimation transformAnimation)
            {
                var source = new TaskCompletionSource<bool>();

                var curve = transformAnimation.Curve.ToNative();
                var from = transformAnimation.From;
                var to = transformAnimation.To;
                var w = (float)view.RenderSize.Width;
                var h = (float)view.RenderSize.Height;

                var transform = new CompositeTransform()
                {
                    CenterX = w / 2,
                    CenterY = h / 2,
                };
                view.RenderTransform = transform;

                var sb = new Storyboard()
                {
                    BeginTime = transformAnimation.Delay,
                    Duration = new Duration(transformAnimation.Duration),
                };

                sb.Completed += (s, e) => source.SetResult(true);

                sb.AddDoubleAnimation(view, "Opacity", transformAnimation.From.Opacity, transformAnimation.To.Opacity, curve);
                sb.AddDoubleAnimation(transform, "ScaleX", transformAnimation.From.ScaleX, transformAnimation.To.ScaleX, curve);
                sb.AddDoubleAnimation(transform, "ScaleY", transformAnimation.From.ScaleY, transformAnimation.To.ScaleY, curve);
                sb.AddDoubleAnimation(transform, "TranslateX", transformAnimation.From.TranslateX * w, transformAnimation.To.TranslateX * w, curve);
                sb.AddDoubleAnimation(transform, "TranslateY", transformAnimation.From.TranslateY * h, transformAnimation.To.TranslateY * h, curve);
                sb.AddDoubleAnimation(transform, "Rotation", transformAnimation.From.Rotation, transformAnimation.To.Rotation, curve);

                sb.Begin();

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
