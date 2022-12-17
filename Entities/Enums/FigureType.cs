using System.ComponentModel;

namespace JPFigure.Entities.Enums
{
	/// <summary>
	/// Loại figure
	/// <para> Dùng <see cref="EnumExtensions.GetDisplayText(Enum)"/>
	/// để lấy text hiển thị cho người dùng </para>
	/// </summary>
	public enum FigureType
	{
		[Description("Scale Figure")]
		ScaleFigure, 
		
		[Description("Nendoroid")]
		Nendoroid, 
		
		[Description("Các loại figure khác")]
		Others,

		[Description("Gundam")]
		Gundam,

		[Description("Gundam")]
		Gundam2,
	}
}
