using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IceWAService
{
    public class Event
    {

        public static Int32 nextID = 0;

        public static Int32 getNextID()
        {
            nextID++;
            return nextID;
        }

        public Int32 eventID;
        public Int32 teamID;
        public DateTime eventTime;
        public string period;

        public Event() { }
        public Event(Int32 team, string period)
        {
            eventID = getNextID();
            teamID = team;
            eventTime = DateTime.Now;
            this.period = period;
        }
    }
}