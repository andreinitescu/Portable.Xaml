using Portable.Xaml.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Portable.Xaml;

namespace XamarinFormsTypeConverters
{
    [Flags]
    public enum BindingFlags
    {
        None = 0,
        Instance = 1,
        Public = 2,
        Static = 4,
        FlattenHierarchy = 8,
        NonPublic = 32,
        SetProperty = 8192
    }

    public static class ReflectionMethods
    {
        public static T GetCustomAttribute<T>(this ICustomAttributeProvider type, bool inherit) where T : Attribute
        {
            foreach (var a in type.GetCustomAttributes(typeof(T), inherit))
                return (T)a;
            return null;
        }

        public static T GetCustomAttribute<T>(this XamlType type) where T : Attribute
        {
            if (type.UnderlyingType == null)
                return null;

            var ret = type.GetCustomAttributeProvider().GetCustomAttribute<T>(true);
            return ret ?? type.BaseType?.GetCustomAttribute<T>();
        }

        public static IEnumerable<FieldInfo> GetStaticFields(this Type type)
        {
            return type
                .GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == type)
                .ToArray();
        }

        public static IEnumerable<FieldInfo> GetFields(this Type type, BindingFlags flags)
        {
            var dfs = type.GetTypeInfo().DeclaredFields;

            if (flags.HasFlag(BindingFlags.FlattenHierarchy))
                dfs = type.GetRuntimeFields();

            return dfs
                .Where(f => (flags & BindingFlags.Public) != BindingFlags.Public || f.IsPublic)
                .Where(f => (flags & BindingFlags.Instance) != BindingFlags.Instance || !f.IsStatic)
                .Where(f => (flags & BindingFlags.Static) != BindingFlags.Static || f.IsStatic);
        }
    }
}
