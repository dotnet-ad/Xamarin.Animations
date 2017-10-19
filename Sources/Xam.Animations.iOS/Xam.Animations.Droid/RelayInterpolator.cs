namespace Xam.Animations
{
    using System;
    using Android.Views.Animations;

    public class RelayInterpolator : Java.Lang.Object, IInterpolator
    {
        public RelayInterpolator(Func<float, float> interpolation)
        {
            this.interpolation = interpolation;
        }

        private Func<float, float> interpolation;

        public float GetInterpolation(float input) => this.interpolation(input);
    }
}
