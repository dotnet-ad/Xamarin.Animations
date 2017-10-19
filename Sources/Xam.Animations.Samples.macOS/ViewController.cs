using System;

using AppKit;
using CoreGraphics;
using Foundation;
using Xam.Animations.Samples.ViewModels;

namespace Xam.Animations.Samples.macOS
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public HomeViewModel ViewModel { get; private set; }

        private NSView view;

        private NSButton button;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Creating views
            this.view = new NSView(new CGRect(50, 50, 50, 50))
            {
                WantsLayer = true,
            };
            this.view.Layer.BackgroundColor = NSColor.Red.CGColor;

            this.View.AddSubview(view);

            // Button
            this.button = new NSButton()
            {
                Frame = new CGRect(50, 200, 300, 100),
            };
            button.Activated += (sender, e) => this.ViewModel.Next();
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
                    button.Title = this.ViewModel.NextTitle;
                    break;
                case nameof(this.ViewModel.Current):
                    await view.AnimateAsync(this.ViewModel.Current);
                    break;
            }
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
