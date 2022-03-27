using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScreenBuilderMVVM.Utilities
{
	public static class Metadata
	{
		static Dictionary<Type, Dictionary<DependencyProperty, object>> standardPropertyValues = new Dictionary<Type, Dictionary<DependencyProperty, object>>();

		public static void AddDefaultPropertyValue(Type t, DependencyProperty p, object value)
		{
			lock (standardPropertyValues)
			{
				if (!standardPropertyValues.ContainsKey(t))
					standardPropertyValues.Add(t, new Dictionary<DependencyProperty, object>());

				standardPropertyValues[t][p] = value;
			}
		}

		/// <summary>
		/// Gets Default Propertie Values for a type
		/// </summary>
		public static Dictionary<DependencyProperty, object> GetDefaultPropertyValues(Type t)
		{
			lock (standardPropertyValues)
			{
				if (standardPropertyValues.ContainsKey(t))
					return standardPropertyValues[t];

				return null;
			}
		}

		public static IEnumerable<FieldInfo> GetDependencyProperties(Type type)
		{
			var dependencyProperties = type.GetFields(BindingFlags.Static | BindingFlags.Public)
										   .Where(p => p.FieldType.Equals(typeof(DependencyProperty)));
			if (type.BaseType != null)
				dependencyProperties = dependencyProperties.Union(GetDependencyProperties(type.BaseType));
			return dependencyProperties;
		}

		static HashSet<Type> popularControls = new HashSet<Type>();

		/// <summary>
		/// Registers a popular control (visible in the default toolbox).
		/// </summary>
		public static void AddPopularControl(Type t)
		{
			lock (popularControls)
			{
				popularControls.Add(t);
			}
		}

	}
}
