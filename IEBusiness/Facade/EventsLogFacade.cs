using System.Collections;
using IE.Model;
namespace IE.Facade
{

    public class EventsLogFacade : BaseFacade
    {
        protected static EventsLogFacade instance = new EventsLogFacade(new EventsLogModel());
        protected EventsLogFacade(EventsLogModel model)
            : base(model)
        {
        }
        public static EventsLogFacade Instance
        {
            get { return instance; }
        }
        protected EventsLogFacade()
            : base()
        {
        }

    }
}