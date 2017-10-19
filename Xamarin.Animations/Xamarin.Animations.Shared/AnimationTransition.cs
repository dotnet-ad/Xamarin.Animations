#if __ANDROID__
namespace Xamarin.Animations.Droid
#elif __UNIFIED__
namespace Xamarin.Animations.iOS
#elif __W_UNIVERSAL__
namespace Xamarin.Animations.Win.Universal
#endif
{
    /// <summary>
    /// Animation transition : entrance or ending.
    /// </summary>
    public enum AnimationTransition
    {
        In,
        Out,
    }
}

