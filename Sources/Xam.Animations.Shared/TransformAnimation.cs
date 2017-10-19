namespace Xam.Animations
{
    using System;

    public class TransformAnimation : IAnimation
    {
        public TransformAnimation(TimeSpan delay, TimeSpan duration, Transform from, Transform to, Curve curve)
        {
            this.Delay = delay;
            this.Duration = duration;
            this.From = from;
            this.To = to;
            this.Curve = curve;
        }

        public TimeSpan Delay { get; }

        public TimeSpan Duration { get; }

        public Transform From { get; }

        public Transform To { get; }

        public Curve Curve { get; }
    }
}
