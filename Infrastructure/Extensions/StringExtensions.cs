using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace TeamBoard.Infrastructure
{
	public static class StringExtensions
	{
		public static string FormatWith(this string format, params object[] args)
		{
			return format.FormatWith(CultureInfo.InvariantCulture, args);
		}

		public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
		{
			if (format == null)
				throw new ArgumentNullException("format");

			return string.Format(provider, format, args);
		}
	}
}
