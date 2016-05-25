using System;

namespace Portable.Xaml.Portable.Xaml
{
    public class EnhancedXamlMethods
    {
        public static Func<XamlType, string> GetContentPropertyName;
        public static Func<object, EnhancedAttachableProperty[]> GetAttachableProperties;

        /// <summary>
        /// Lookup the type's content property name.
        /// </summary>
        /// <param name="xt"></param>
        /// <returns></returns>
        internal static string LookupContentProperty(XamlType xt)
        {
            return GetContentPropertyName?.Invoke(xt);
        }

        /// <summary>
        /// Lookup the attachable properties for the <paramref name="obj"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static EnhancedAttachableProperty[] LookupEnhancedAttachableProperties(object obj)
        {
            return GetAttachableProperties?.Invoke(obj);
        }
    }
}