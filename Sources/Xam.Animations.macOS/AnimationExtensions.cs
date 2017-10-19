namespace Xam.Animations
{
    using System;
    using System.Threading.Tasks;
    using CoreGraphics;
    using Foundation;
    using AppKit;
    using CoreAnimation;

    public static class AnimationExtensions
    {
        internal static CATransform3D ToNative(this Transform transform, CGSize size)
        {
            //Weird behaviour with 0.
            var scaleX = Math.Max(0.001f, transform.ScaleX);
            var scaleY = Math.Max(0.001f, transform.ScaleY);

            var result = CATransform3D.Identity;
            result.Scale(scaleX, scaleY,1);
            result.Rotate(transform.Rotation,0,0,1);
            result.Translate(transform.TranslateX * size.Width, transform.TranslateY * size.Height, 0);
            return result;
        }

        internal static CAMediaTimingFunction ToNative(this Curve curve)
        {
            switch (curve)
            {
                case Curve.EaseIn:
                    return CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseIn);
                case Curve.EaseOut:
                    return CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseOut);
                default:
                    throw new InvalidOperationException();
            }
        }

        internal static CALayer AddAnimation(this CALayer layer, string name, CAMediaTimingFunction curve, float from, float to, Action<CABasicAnimation> init = null)
        {
            var basic = CABasicAnimation.FromKeyPath(name);
            basic.TimingFunction = curve;
            basic.From = new NSNumber(from);
            basic.To = new NSNumber(to);
            init?.Invoke(basic);
            layer.AddAnimation(basic, name);
            return layer;
        }

        public static async Task AnimateAsync(this NSView view, IAnimation animation)
        {
            // Tell the view to create a backing layer.
            view.WantsLayer = true;
            view.LayerContentsRedrawPolicy = NSViewLayerContentsRedrawPolicy.OnSetNeedsDisplay;

            if (animation is TransformAnimation transformAnimation)
            {
                view.Layer.AnchorPoint = new CGPoint(0.5f, 0.5f);

                var source = new TaskCompletionSource<bool>();

                var curve = transformAnimation.Curve.ToNative();
                var from = transformAnimation.From;
                var to = transformAnimation.To;
                var w = (float)view.Bounds.Width;
                var h = (float)view.Bounds.Height;

                view.Layer.AddAnimation("opacity", curve, from.Opacity, to.Opacity, (anim) => anim.AnimationStopped += (sender, e) => source.SetResult(true))
                          .AddAnimation("transform.scale.x", curve, from.ScaleX, to.ScaleX)
                          .AddAnimation("transform.scale.y", curve, from.ScaleY,to.ScaleY)
                          .AddAnimation("transform.translation.x", curve, from.TranslateX * w, to.TranslateX * w)
                          .AddAnimation("transform.translation.y", curve, -1 * from.TranslateY * h, -1 * to.TranslateY * h)
                          .AddAnimation("transform.rotation.z", curve, from.Rotation, to.Rotation);
                
                view.Layer.Opacity = transformAnimation.To.Opacity;
                view.Layer.Transform = transformAnimation.To.ToNative(view.Bounds.Size);

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
