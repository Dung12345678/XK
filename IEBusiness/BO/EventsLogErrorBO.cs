
using System;
using System.Collections;
using IE.Exceptions;
using IE.Utils;
using IE.Facade;
using IE.Model;
namespace IE.Business
{

	
	public class EventsLogErrorBO : BaseBO
	{
		private EventsLogErrorFacade facade = EventsLogErrorFacade.Instance;
		protected static EventsLogErrorBO instance = new EventsLogErrorBO();

		protected EventsLogErrorBO()
		{
			this.baseFacade = facade;
		}

		public static EventsLogErrorBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	