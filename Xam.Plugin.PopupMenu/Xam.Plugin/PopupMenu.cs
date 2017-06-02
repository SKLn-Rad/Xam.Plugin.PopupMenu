using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System;

namespace Xam.Plugin
{
    public class PopupMenu : BindableObject
    {

        #region events and delegates
        public delegate void PopupShowRequestDelegate(View view);
        public event PopupShowRequestDelegate OnPopupRequest;

        public delegate void ItemSelectedDelegate(string item);
        public event ItemSelectedDelegate OnItemSelected;
        #endregion

        #region fields
        InternalPopupEffect _internalEffect;
        
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(PopupMenu), default(IList));
        #endregion

        #region properties
        public IList ItemsSource
        {
            get { return (IList) GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public InternalPopupEffect InternalEffect
        {
            get { return _internalEffect; }
        }
        #endregion

        #region construction
        public PopupMenu()
        {
            _internalEffect = new InternalPopupEffect(this);
        }
        #endregion

        #region methods
        public void ShowPopup(View sender)
        {
            var effects = sender.Effects.Where(c => c is InternalPopupEffect).ToList();

            // Remove all old popups
            if (effects.Count > 0 && (effects[0] != InternalEffect))
                foreach (var effect in effects)
                    sender.Effects.Remove(effect);
            
            // Add new popup
            sender.Effects.Add(InternalEffect);

            // Invoke
            OnPopupRequest?.Invoke(sender);
        }

        public void InvokeItemSelected(string item) => OnItemSelected?.Invoke(item);
        #endregion

        #region classes
        /// <summary>
        /// INTERNAL USE ONLY.
        /// This is used by the Popup Menu as routing effects can not normally be bound, this provides the routing effect whereas the PopupMenu provides the bindable.
        /// </summary>
        public sealed class InternalPopupEffect : RoutingEffect
        {
            public PopupMenu Parent;
            internal InternalPopupEffect(PopupMenu menu) : base("Xam.Plugin.PopupEffect")
            {
                Parent = menu;
            }   
        }
        #endregion
    }
}
