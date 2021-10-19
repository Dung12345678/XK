
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class AddAutoXKNewBO : BaseBO
	{
		private AddAutoXKNewFacade facade = AddAutoXKNewFacade.Instance;
		protected static AddAutoXKNewBO instance = new AddAutoXKNewBO();

		protected AddAutoXKNewBO()
		{
			this.baseFacade = facade;
		}

		public static AddAutoXKNewBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	