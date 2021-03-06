#if PCL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Portable.Xaml.ComponentModel
{

	/// <summary>
	/// Type descriptor for conversion compatibility.
	/// </summary>
	public static class TypeDescriptor
	{
        static readonly Dictionary<Type, Type> converters = new Dictionary<Type, Type>
		{
			{ typeof(bool), typeof(BoolConverter) },
			{ typeof(char), typeof(CharConverter) },
			{ typeof(byte), typeof(ByteConverter) },
			{ typeof(Single), typeof(SingleConverter) },
			{ typeof(Double), typeof(DoubleConverter) },
			{ typeof(Decimal), typeof(DecimalConverter) },
			{ typeof(Int16), typeof(Int16Converter) },
			{ typeof(Int32), typeof(Int32Converter) },
			{ typeof(Int64), typeof(Int64Converter) },
			{ typeof(UInt16), typeof(UInt16Converter) },
			{ typeof(UInt32), typeof(UInt32Converter) },
			{ typeof(UInt64), typeof(UInt64Converter) },
			{ typeof(string), typeof(StringConverter) },
			{ typeof(Guid), typeof(GuidConverter) },
			{ typeof(Uri), typeof(UriTypeConverter) },
			{ typeof(TimeSpan), typeof(TimeSpanConverter) },
			{ typeof(DateTime), typeof(DateTimeConverter) }
		};

        static readonly Dictionary<Type, Type> redirects = new Dictionary<Type, Type>();
        public static Func<object, Type> GetRedirect;

        /// <summary>
        /// Add a type converter to the recognized list.
        /// Used when you don't maintain the types.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        [EnhancedXaml]
        public static bool Register(Type type, Type converter)
	    {
            if (converters.ContainsKey(type)) return false;
            converters[type] = converter;
            return true;
	    }

        /// <summary>
        /// Add a type converter redirect.
        /// </summary>
        /// <param name="xtc"></param>
        /// <param name="ptc"></param>
        /// <returns></returns>
        [EnhancedXaml]
	    public static bool Redirect(Type xtc, Type ptc)
	    {
	        if (redirects.ContainsKey(xtc)) return false;
	        redirects[xtc] = ptc;
	        return true;
	    }

        /// <summary>
        /// Lookup a type converter redirect.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [EnhancedXaml]
	    public static TypeConverter GetConverter(object obj)
        {
            var tc = GetRedirect?.Invoke(obj);
            if (tc == null) return null;

            return Activator.CreateInstance(tc) as TypeConverter;
        }

		/// <summary>
		/// Gets the type converter for the specified type.
		/// </summary>
		/// <returns>The type converter, or null if the type has no defined converter.</returns>
		/// <param name="type">Type to get the converter for.</param>
		public static TypeConverter GetConverter(Type type)
		{
			var attr = type.GetTypeInfo().GetCustomAttribute<TypeConverterAttribute>();
			Type converterType = null;

            if (attr != null)
		    {
		        converterType = Type.GetType(attr.ConverterTypeName);
		    }

			if (converterType == null)
			{
				if (!converters.TryGetValue(type, out converterType))
				{
					if (type.GetTypeInfo().IsGenericType && type.GetTypeInfo().GetGenericTypeDefinition() == typeof(Nullable<>))
						return new NullableConverter(type);
					if (type.GetTypeInfo().IsEnum)
						return new EnumConverter(type);
					if (typeof(Delegate).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
						return new EventConverter();
				}
			}
			
			if (converterType != null)
			{
				if (converterType.GetTypeInfo().GetConstructors().Any(r => r.GetParameters().Select(p => p.ParameterType).SequenceEqual(new [] { typeof(Type) })))
					return Activator.CreateInstance(converterType, type) as TypeConverter;
				return Activator.CreateInstance(converterType) as TypeConverter;
			}
			
			return null;
		}
	}
	
}
#endif