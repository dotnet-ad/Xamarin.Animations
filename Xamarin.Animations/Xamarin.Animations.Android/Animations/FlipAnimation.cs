namespace Xamarin.Animations.Droid.Animations
{
    using Android.Graphics;
    using Android.Views.Animations;

    /// <summary>
    /// A flip animation.
    /// </summary>
    public class FlipAnimation : Animation 
    {
        public FlipAnimation(float fromDegrees, float toDegrees, float centerX, float centerY) {
            this.fromDegrees = fromDegrees;
            this.toDegrees = toDegrees;
            this.centerX = centerX;
            this.centerY = centerY;
        }

        private float fromDegrees;
        private float toDegrees;
        private float centerX;
        private float centerY;
        private Camera camera;

        public override void Initialize(int width, int height, int parentWidth, int parentHeight)
        {
            base.Initialize(width, height, parentWidth, parentHeight);
            this.camera = new Camera();
        }
    

        protected override void ApplyTransformation(float interpolatedTime, Transformation t)
        {
            float degrees = this.fromDegrees + (this.toDegrees - this.fromDegrees) * interpolatedTime;

            this.camera.Save();

            this.camera.RotateY(degrees);
            this.camera.GetMatrix(t.Matrix);
            this.camera.Restore();

            t.Matrix.PreTranslate(-this.centerX, -this.centerY);
            t.Matrix.PostTranslate(this.centerX, this.centerY); 
        }
    }
}