
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class WorkingStepBO : BaseBO
	{
		private WorkingStepFacade facade = WorkingStepFacade.Instance;
		protected static WorkingStepBO instance = new WorkingStepBO();

		protected WorkingStepBO()
		{
			this.baseFacade = facade;
		}

		public static WorkingStepBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	