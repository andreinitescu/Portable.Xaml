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

        public static MethodInfo GetMethod(this Type type, string name)
        {
            return GetMethods(type, BindingFlags.Public | BindingFlags.FlattenHierarchy)
                   .FirstOrDefault(m => m.Name == name);
        }

        public static IEnumerable<MethodInfo> GetMethods(this Type type, BindingFlags flags)
        {
            var properties = type.GetTypeInfo().DeclaredMethods;
            if ((flags & BindingFlags.FlattenHierarchy) == BindingFlags.FlattenHierarchy)
            {
                properties = type.GetRuntimeMethods();
            }

            return properties
                .Where(m => (flags & BindingFlags.Public) != BindingFlags.Public || m.IsPublic)
                .Where(m => (flags & BindingFlags.Instance) != BindingFlags.Instance || !m.IsStatic)
                .Where(m => (flags & BindingFlags.Static) != BindingFlags.Static || m.IsStatic);
        }

        public static string GetShortTypeName(string typeName)
        {
            if (string.IsNullOrWhiteSpace(typeName))
            {
                return string.Empty;
            }

            var isNullable = false;

            if (typeName.Contains(","))
            {
                var split = typeName.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)[0];
                return GetShortTypeName(split);
            }

            if (!typeName.Contains("."))
            {
                return typeName;
            }

            if (typeName.Contains("System.Nullable"))
            {
                isNullable = true;
            }

            var index = typeName.LastIndexOf(".", StringComparison.CurrentCultureIgnoreCase);
            var start = index + 1;

            if (typeName.EndsWith(".", StringComparison.CurrentCultureIgnoreCase))
            {
                return typeName;
            }

            var str = typeName.Substring(start);

            if (isNullable)
            {
                str += "?";
            }

            return str;
        }
    }
}
