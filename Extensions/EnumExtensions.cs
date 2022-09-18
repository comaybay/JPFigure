using System.ComponentModel;
using System.Reflection;

namespace JPFigure.Extensions
{
	public static class EnumExtensions
	{
		/// <summary>
		/// Lấy text dùng để hiển thị cho trang web
		/// </summary>
		public static string? GetDisplayText(this Enum value)
		{
			Type type = value.GetType();
			var name = Enum.GetName(type, value);
			if (name == null)
				return null;

			var field = type.GetField(name);
			if (field == null)
				return null;
			
			var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
			return attr?.Description;
		}
	}
}
