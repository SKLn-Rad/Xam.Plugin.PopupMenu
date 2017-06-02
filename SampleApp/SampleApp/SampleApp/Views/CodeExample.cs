using SampleApp.ViewModels;
using Xam.Plugin;
using Xamarin.Forms;

namespace SampleApp.Views
{
    public class CodeExample : ContentPage
    {

        public SampleViewModel ViewModel => SampleViewModel.Instance;
        public StackLayout MainLayout;
        public Button ShowPopup;
        public PopupMenu Popup;

        public CodeExample()
        {
            BindingContext = ViewModel;
            Popup = new PopupMenu();

            MainLayout = new StackLayout()
            {
                BackgroundColor = Color.Red.WithLuminosity(0.8).WithSaturation(0.8)
            };

            ShowPopup = new Button()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Blue.WithLuminosity(0.8).WithSaturation(0.8),
                TextColor = Color.White,
                Text = "Click me to open menu"
            };

            ShowPopup.Clicked += (sender, args) => Popup?.ShowPopup(sender as Button);
            Popup.BindingContext = ViewModel;
            Popup.SetBinding(PopupMenu.ItemsSourceProperty, "ListItems");

            MainLayout.Children.Add(ShowPopup);
            Content = MainLayout;
        }

    }
}
