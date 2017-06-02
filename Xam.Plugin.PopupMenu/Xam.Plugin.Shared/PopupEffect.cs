using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xam.Plugin;
using Xam.Plugin.Shared;
using Xamarin.Forms;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using System.Collections.Specialized;
using static Xam.Plugin.PopupMenu;

#if WINDOWS_UWP
using Xamarin.Forms.Platform.UWP;
#else
using Xamarin.Forms.Platform.WinRT;
#endif

[assembly: ResolutionGroupName("Xam.Plugin")]
[assembly: ExportEffect(typeof(Xam.Plugin.Shared.PopupEffect), "PopupEffect")]
namespace Xam.Plugin.Shared
{
    public class PopupEffect : PlatformEffect
    {

        MenuFlyout ToggleMenu;
        InternalPopupEffect Effect;

        public static void Init()
        {
            var now = DateTime.Now;
        }

        protected override void OnAttached()
        {
            Effect = (InternalPopupEffect)Element.Effects.FirstOrDefault(e => e is InternalPopupEffect);

            if (Effect != null)
                Effect.Parent.OnPopupRequest += OnPopupRequest;

            if (Control != null || Container != null)
                ToggleMenu = new MenuFlyout();
        }

        void OnElementClicked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Effect?.Parent.InvokeItemSelected(((MenuFlyoutItem)sender).Text);
        }

        void OnPopupRequest(View view)
        {
            // Null Check
            if (Effect.Parent.ItemsSource == null)
                return;

            // Clear Old
            foreach (var item in ToggleMenu.Items)
                ((MenuFlyoutItem)item).Click -= OnElementClicked;
            ToggleMenu.Items.Clear();

            // Add New
            foreach (var item in Effect.Parent.ItemsSource)
            {
                MenuFlyoutItem Item = new MenuFlyoutItem();
                Item.Text = item.ToString();
                Item.Click += OnElementClicked;
                ToggleMenu.Items.Add(Item);
            }

            // Popup
            if (Control != null)
                ToggleMenu.ShowAt(Control);

            else if (Container != null)
                ToggleMenu.ShowAt(Container);
        }

        protected override void OnDetached()
        {
            if (Effect != null)
                Effect.Parent.OnPopupRequest -= OnPopupRequest;
        }
    }
}
