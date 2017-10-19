#if __ANDROID__
namespace Xamarin.Animations.Droid
#elif __UNIFIED__
namespace Xamarin.Animations.iOS
#endif
{
    /// <summary>
    /// Animation movement direction.
    /// </summary>
    public enum AnimationDirection
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }
}

