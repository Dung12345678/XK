using System;
using System.Collections;
using IE.BO;
using IE.Exceptions;
using IE.Utils;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class EventsLogBO : BaseBO
	{
		private EventsLogFacade facade = EventsLogFacade.Instance;
		protected static EventsLogBO instance = new EventsLogBO();

		protected EventsLogBO()
		{
			this.baseFacade = facade;
		}

		public static EventsLogBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	