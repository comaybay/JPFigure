using System.ComponentModel;

namespace JPFigure.Entities.Enums
{
	/// <summary>
	/// Loại figure
	/// </summary>
	public enum FigureType
	{
		[Description("Scale Figure")]
		ScaleFigure, 
		
		[Description("Nendoroid")]
		Nendoroid, 
		
		[Description("Pop Up Parade")]
		PopUpParade, 
		
		[Description("Figma")]
		Figma, 
		
		[Description("Các loại figure khác")]
		Others
	}
}
