#if __ANDROID__
namespace Xamarin.Animations.Droid
#elif __UNIFIED__
namespace Xamarin.Animations.iOS
#endif
{
    using System;

    #if __ANDROID__
    using PlatformFloat = System.Double;
        
    
#elif __UNIFIED__
    using PlatformFloat = System.nfloat;
    #endif

    public static class AnimationConstants
    {
        /// <summary>
        /// The default duration for all animations.
        /// </summary>
        public const double DefaultDuration = 0.30;

        /// <summary>
        /// The m34 for flip animations matrix.
        /// </summary>
        public static PlatformFloat M34 = (PlatformFloat)(-1 * 0.001);

        /// <summary>
        /// The minimum alpha.
        /// </summary>
        public static PlatformFloat MinAlpha = (PlatformFloat)0.0f;

        /// <summary>
        /// The maximum alpha.
        /// </summary>
        public static PlatformFloat MaxAlpha = (PlatformFloat)1.0f;
  
        /// <summary>
        /// The starting angle for rotation animation.
        /// </summary>
        public static double RotationAngle = 720;
    }
}

