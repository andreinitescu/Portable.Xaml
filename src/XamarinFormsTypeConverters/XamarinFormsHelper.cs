using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Portable.Xaml.Portable.Xaml;
using Xamarin.Forms;

namespace XamarinFormsTypeConverters
{
    public class XamarinFormsHelper
    {
        public static Element GetParent(Element o)
        {
            return o?.Parent;
        }


        public static Element[] GetParents(Element o)
        {
            var parents = new List<Element>();
            var current = o;

            while (current != null)
            {
                if (current.Parent != null)
                {
                    parents.Add(current.Parent);
                }

                current = current.Parent;
            }

            return parents.ToArray();
        }


        public static EnhancedAttachedProperty[] GetAttachableProperties(BindableObject obj)
        {
            var result = new List<EnhancedAttachedProperty>();

            var dps = obj
                .GetType()
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(t => t.FieldType.GetTypeInfo().IsAssignableFrom(typeof(BindableProperty).GetTypeInfo()))
                .ToArray();

            foreach (var dp in dps)
            {
                if (!dp.Name.EndsWith("Property", StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }

                var index = dp.Name.LastIndexOf("Property", StringComparison.CurrentCultureIgnoreCase);
                var shortName = dp.Name.Substring(0, index);

                var getMethod = obj.GetType().GetMethod("Get" + shortName);
                var setMethod = obj.GetType().GetMethod("Set" + shortName);

                if (getMethod != null && setMethod != null)
                {
                    var typeName = ReflectionMethods.GetShortTypeName(obj.GetType().FullName);

                    var api = new EnhancedAttachedProperty
                    {
                        ShortName = shortName,
                        PropertyName = dp.Name,
                        XamlPropertyName = $"{typeName}.{shortName}",
                        Value = getMethod.Invoke(null, new object[] { obj }),
                        Field = dp,
                        GetMethod = getMethod,
                        SetMethod = setMethod,
                        Target = obj
                    };

                    result.Add(api);
                }
            }

            return result.ToArray();
        }
    }
}