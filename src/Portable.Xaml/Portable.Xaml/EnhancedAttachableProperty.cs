using System.Reflection;

namespace Portable.Xaml.Portable.Xaml
{
    public class EnhancedAttachableProperty
    {
        public object Target { get; set; }
        public object Value { get; set; }
        public FieldInfo Field { get; set; }
        public MethodInfo GetMethod { get; set; }
        public MethodInfo SetMethod { get; set; }
        public string XamlPropertyName { get; set; }
        public string PropertyName { get; set; }
    }
}