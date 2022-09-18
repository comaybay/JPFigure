using System.ComponentModel;

namespace JPFigure.Entities.Enums
{

	/// <summary>
	/// Tỉ lệ của figure
	/// </summary>
	public enum FigureScale
	{
		[Description("1/12")]
		OneTwelveth,

		[Description("1/10")]
		OneTenth,

		[Description("1/8")]
		OneEight, 
		
		[Description("1/7")] 
		OneSeventh, 

		[Description("1/6")]
		OneSixth, 
		
		[Description("1/5")] 
		OneFifth, 

		[Description("1/4")] 
		OneFourth, 
		
		[Description("1/3")] 
		OneThird, 
		
		[Description("Không theo tỉ lệ")] 
		NonScale
	}
}

