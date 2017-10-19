namespace Xam.Animations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SequenceAnimation : List<IAnimation>, IAnimation
    {
        public TimeSpan Delay => TimeSpan.Zero;

        public TimeSpan Duration => new TimeSpan(this.Sum(x => x.Delay.Ticks + x.Duration.Ticks));
    }
}
