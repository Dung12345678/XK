
using System;
using System.Collections;
using IE.BO;
using IE.Exceptions;
using IE.Utils;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class ActivityLogBO : BaseBO
	{
		private ActivityLogFacade facade = ActivityLogFacade.Instance;
		protected static ActivityLogBO instance = new ActivityLogBO();

		protected ActivityLogBO()
		{
			this.baseFacade = facade;
		}

		public static ActivityLogBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	