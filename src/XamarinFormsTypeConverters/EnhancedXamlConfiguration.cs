using System;
using System.Collections.Generic;
using System.Linq;
using Portable.Xaml.ComponentModel;
using Portable.Xaml.Portable.Xaml;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public static class EnhancedXamlConfiguration
    {
        private static readonly Dictionary<Type, Type> Redirects = new Dictionary<Type, Type>
        {
            {typeof(FontSizeConverter), typeof(XamlFontSizeConverter)},
            {typeof(Xamarin.Forms.UriTypeConverter), typeof(XamlUriTypeConverter)},
            {typeof(GridLengthTypeConverter), typeof(XamlGridLengthTypeConverter)},
        };

        private static readonly Dictionary<Type, Type> Converters = new Dictionary<Type, Type>
        {
            { typeof(Enum), typeof(EnumConverter)},
            { typeof(Button.ButtonContentLayout), typeof(XamlButtonContentTypeConverter) },
            { typeof(Color), typeof(XamlColorTypeConverter) },
            { typeof(FileImageSource), typeof(XamlFileImageSourceConverter) },
            { typeof(Font), typeof(XamlFontTypeConverter) },
            { typeof(GridLength), typeof(XamlGridLengthTypeConverter) },
            { typeof(ImageSource), typeof(XamlImageSourceConverter) },
            { typeof(Keyboard), typeof(XamlKeyboardTypeConverter) },
            { typeof(LayoutOptions), typeof(XamlLayoutOptionsConverter) },
            { typeof(Point), typeof(XamlPointTypeConverter) },
            { typeof(Rectangle), typeof(XamlRectangleTypeConverter) },
            { typeof(Thickness), typeof(XamlThicknessTypeConverter) },
            { typeof(Uri), typeof(XamlUriTypeConverter) },
            { typeof(WebViewSource), typeof(XamlWebViewSourceTypeConverter) },
        };


        public static void Initialize()
        {
            foreach (var converter in Converters)
            {
                TypeDescriptor.Register(converter.Key, converter.Value);
            }

            foreach (var redirect in Redirects)
            {
                TypeDescriptor.Redirect(redirect.Key, redirect.Value);
            }

            TypeDescriptor.GetRedirect = o =>
            {
                var tca = o as Xamarin.Forms.TypeConverterAttribute;

                return Redirects
                    .FirstOrDefault(r => r.Key.AssemblyQualifiedName.Equals(tca?.ConverterTypeName))
                    .Value;
            };

            EnhancedXamlMethods.GetContentPropertyName = t => t?.GetCustomAttribute<ContentPropertyAttribute>()?.Name;

            EnhancedXamlMethods.GetAttachedProperties = o =>
            {
                var e = o as Element;
                if (e == null) return null;

                var parent = XamarinFormsHelper.GetParent(e);

                return parent == null 
                    ? null 
                    : XamarinFormsHelper.GetAttachableProperties(parent);
            };
        }
    }
}