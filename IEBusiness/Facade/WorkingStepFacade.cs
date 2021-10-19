
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class WorkingStepFacade : BaseFacade
	{
		protected static WorkingStepFacade instance = new WorkingStepFacade(new WorkingStepModel());
		protected WorkingStepFacade(WorkingStepModel model) : base(model)
		{
		}
		public static WorkingStepFacade Instance
		{
			get { return instance; }
		}
		protected WorkingStepFacade():base() 
		{ 
		} 
	
	}
}
	