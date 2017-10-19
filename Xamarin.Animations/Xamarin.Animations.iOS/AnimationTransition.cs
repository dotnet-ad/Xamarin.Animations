#if __ANDROID__
namespace Xamarin.Animations.Droid
#elif __UNIFIED__
namespace Xamarin.Animations.iOS
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

