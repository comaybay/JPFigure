using System.ComponentModel;

namespace JPFigure.Entities.Enums
{
	public enum GundamType
	{
		[Description("Super Deformed")]
		SuperDeformed,

		[Description("High Grade")]
		HighGrade,

		[Description("Real Grade")]
		RealGrade,  
		
		[Description("Master Grade")] 
		MasterGrade, 
		
		[Description("Perfect Grade")] 
		PerfectGrade,
		
		[Description("Non Gundam")]
		NonGundam
	}
}
