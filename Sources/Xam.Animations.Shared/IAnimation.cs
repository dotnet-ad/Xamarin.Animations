namespace Xam.Animations
{
    using System;

    public interface IAnimation
    {
        TimeSpan Delay { get; }

        TimeSpan Duration { get; }
    }
}
