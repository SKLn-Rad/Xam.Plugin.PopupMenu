using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xam.Plugin.Droid;
using Android.Views;
using static Xam.Plugin.PopupMenu;

[assembly: ResolutionGroupName("Xam.Plugin")]
[assembly: ExportEffect(typeof(PopupEffect), "PopupEffect")]
namespace Xam.Plugin.Droid
{
    public class PopupEffect : PlatformEffect
    {

        Android.Widget.PopupMenu ToggleMenu;
        InternalPopupEffect Effect;
        
        public static void Init()
        {
            var now = DateTime.Now;
        }

        protected override void OnAttached()
        {
            Effect = (InternalPopupEffect) Element.Effects.FirstOrDefault(e => e is InternalPopupEffect);

            if (Effect != null)
                Effect.Parent.OnPopupRequest += OnPopupRequest;

            if (Control != null)
            {
                ToggleMenu = new Android.Widget.PopupMenu(Forms.Context, Control);
                ToggleMenu.MenuItemClick += MenuItemClick;
            }

            else if (Container != null)
            {
                ToggleMenu = new Android.Widget.PopupMenu(Forms.Context, Container);
                ToggleMenu.MenuItemClick += MenuItemClick;
            }
        }

        void OnPopupRequest(Xamarin.Forms.View view)
        {
            // Null Check
            if (Effect.Parent.ItemsSource == null)
                return;

            // Clear Old
            ToggleMenu.Menu.Clear();

            // Add New
            foreach (var item in Effect.Parent.ItemsSource)
                ToggleMenu.Menu.Add(item.ToString());

            // Popup
            ToggleMenu.Show();
        }

        protected override void OnDetached()
        {
            if (ToggleMenu != null)
                ToggleMenu.MenuItemClick -= MenuItemClick;

            if (Effect != null)
                Effect.Parent.OnPopupRequest -= OnPopupRequest;
        }

        void MenuItemClick(object sender, Android.Widget.PopupMenu.MenuItemClickEventArgs e) => Effect?.Parent.InvokeItemSelected(e.Item.ToString());
    }
}