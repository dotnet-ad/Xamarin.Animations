namespace Xam.Animations
{
    public class Transform
    {
        public Transform(float opacity = 1, float scaleX = 1, float scaleY = 1, float rotation = 0, float translateX = 0, float translateY = 0)
        {
            this.Opacity = opacity;
            this.Rotation = rotation;
            this.ScaleX = scaleX;
            this.ScaleY = scaleY;
            this.TranslateX = translateX;
            this.TranslateY = translateY;
        }

        public float Opacity { get; }

        public float ScaleX { get; }

        public float ScaleY { get; }

        public float Rotation { get; }

        public float TranslateX { get; } // where 1 == Width

        public float TranslateY { get; } // where 1 == Height
    }
}
