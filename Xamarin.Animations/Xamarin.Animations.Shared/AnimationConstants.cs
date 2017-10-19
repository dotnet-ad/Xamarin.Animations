#if __ANDROID__
namespace Xamarin.Animations.Droid
#elif __UNIFIED__
namespace Xamarin.Animations.iOS
#elif __W_UNIVERSAL__
namespace Xamarin.Animations.Win.Universal
#endif
{
	using System;

	public static class AnimationConstants
	{
		/// <summary>
		/// The default duration for all animations.
		/// </summary>
		public const double DefaultDuration = 0.30;

		/// <summary>
		/// The m34 for flip animations matrix.
		/// </summary>
		public const double M34 = (-1 * 0.001);

		/// <summary>
		/// The minimum alpha.
		/// </summary>
		public const double MinAlpha = 0.0f;

		/// <summary>
		/// The maximum alpha.
		/// </summary>
		public const double MaxAlpha = 1.0f;

		/// <summary>
		/// Minimum scale.
		/// </summary>
		public const double MinScale = 0.1f;

		/// <summary>
		/// Maximum zoom scale.
		/// </summary>
		public const double MaxScale = 1.0f;

		/// <summary>
		/// Minimum zoom scale.
		/// </summary>
		public const double MinZoom = 2.0f;

		/// <summary>
		/// Maximum scale.
		/// </summary>
		public const double MaxZoom = 1.0f;

		/// <summary>
		/// The starting angle for rotation animation.
		/// </summary>
		public static double RotationAngle = 720;
	}
}

