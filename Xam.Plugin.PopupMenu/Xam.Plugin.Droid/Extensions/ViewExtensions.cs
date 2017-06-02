using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace Xam.Plugin.Droid.Extensions
{
    using NativeView = Android.Views.View;
    public static class ViewExtensions
    {

        /// <summary>
        /// Gets the content of the native.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <returns>NativeView.</returns>
        public static NativeView GetNativeContent(this View view)
        {
            PropertyInfo controlProperty = view.GetType().GetProperty("Control", BindingFlags.Public | BindingFlags.Instance);
            return (controlProperty == null) ? null : controlProperty.GetValue(view) as NativeView;
        }

    }
}