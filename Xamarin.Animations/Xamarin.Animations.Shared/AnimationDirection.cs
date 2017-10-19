#if __ANDROID__
namespace Xamarin.Animations.Droid
#elif __UNIFIED__
namespace Xamarin.Animations.iOS
#elif __W_UNIVERSAL__
namespace Xamarin.Animations.Win.Universal
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

