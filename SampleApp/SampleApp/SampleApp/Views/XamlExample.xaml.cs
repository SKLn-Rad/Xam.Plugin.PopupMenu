using SampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xam.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XamlExample : ContentPage
    {

        public SampleViewModel ViewModel => SampleViewModel.Instance;
        public PopupMenu Popup;

        public XamlExample()
        {
            InitializeComponent();
            
            Popup = new PopupMenu()
            {
                BindingContext = ViewModel
            };

            Popup.SetBinding(PopupMenu.ItemsSourceProperty, "ListItems");
        }

        void ShowPopup_Clicked(object sender, EventArgs e) => Popup?.ShowPopup(sender as View);
    }
}
