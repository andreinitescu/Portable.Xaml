using System;

namespace Portable.Xaml.Portable.Xaml
{
    public class EnhancedXamlMethods
    {
        public static Func<XamlType, string> GetContentPropertyName;

        /// <summary>
        /// Lookup the type's content property name.
        /// </summary>
        /// <param name="xt"></param>
        /// <returns></returns>
        internal static string LookupContentProperty(XamlType xt)
        {
            return GetContentPropertyName?.Invoke(xt);
        }
    }
}