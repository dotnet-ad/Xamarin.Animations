using System;

using UIKit;
using CoreGraphics;
using Xam.Animations.Samples.ViewModels;

namespace Xam.Animations.Samples.iOS
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public HomeViewModel ViewModel { get; private set; }

        private UIView view;

        private UIButton button;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Creating views
            this.view = new UIView(new CGRect(50, 50, 50, 50))
            {
                BackgroundColor = UIColor.Red,
            };

            this.View.AddSubview(view);

            // Button
            this.button = new UIButton()
            {
                Frame = new CGRect(50, 200, 300, 100),
            };
            button.TouchUpInside += (sender, e) => this.ViewModel.Next();
            this.View.AddSubview(button);


            // View model initialization
            this.ViewModel = new HomeViewModel();
            this.OnViewModelPropertyChanged(nameof(this.ViewModel.NextTitle));
            this.OnViewModelPropertyChanged(nameof(this.ViewModel.Current));
            this.ViewModel.PropertyChanged += (s, e) => this.OnViewModelPropertyChanged(e.PropertyName);
        }

        async void OnViewModelPropertyChanged(string property)
        {
            switch (property)
            {
                case nameof(this.ViewModel.NextTitle):
                    button.SetTitle(this.ViewModel.NextTitle, UIControlState.Normal);
                    break;
                case nameof(this.ViewModel.Current):
                    await view.AnimateAsync(this.ViewModel.Current);
                    break;
            }
        }
    }
}
