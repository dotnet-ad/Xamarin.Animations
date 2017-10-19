using Windows.UI.Xaml.Controls;
using Xam.Animations.Samples.ViewModels;

namespace Xam.Animations.Samples.Uwp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

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
                    button.Content = this.ViewModel.NextTitle;
                    break;
                case nameof(this.ViewModel.Current):
                    await view.AnimateAsync(this.ViewModel.Current);
                    break;
            }
        }

        public HomeViewModel ViewModel { get; private set; }

        private void button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e) => this.ViewModel.Next();
    }
}
