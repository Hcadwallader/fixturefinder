using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FixtureFinder.Models
{
    public class Eventsorter
    {
        public List<Event> SortByTravelTime(List<Event>originalEvents)
        {
            List<Event> sortedList = new List<Event>();

            int numberOfEventsInList = originalEvents.Count();

            for (int x=0; x<numberOfEventsInList; x++)
            { 
                    //naming result of findShortestDistance method
                    //calling method to be applied
                    Event e = findClosestEvent(originalEvents);
                    //add shortest distance to sorted list
                    sortedList.Add(e);
                    //delete event from orginalEvents list 
                    originalEvents.Remove(e);
            }

            return sortedList;
        }

        public Event findClosestEvent(List<Event> originalEvents)
        {
            Event shortDistanceEvent = new Event();
            int numberOfEventsInList = originalEvents.Count();
            int distance = 100000000;

            foreach (Event e in originalEvents)
            {
                if (distance > e.duration)
                {
                    distance = e.duration;
                    shortDistanceEvent = e;
                }
            }

            return shortDistanceEvent;
            
        }



        //sortByTravelTime.sort();
        //foreach (Event event in events)
        //{
        //    return events;
        //}
    }
}