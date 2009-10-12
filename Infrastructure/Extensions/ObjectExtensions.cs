using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TeamBoard.Infrastructure
{
	public static class ObjectExtensions
	{
		public static IDictionary<string, object> ToDictionary(this object obj)
		{
			var result = new Dictionary<string, object>();
			var properties = TypeDescriptor.GetProperties(obj);

			foreach (PropertyDescriptor property in properties)
				result.Add(property.Name, property.GetValue(obj));

			return result;
		}
	}
}
