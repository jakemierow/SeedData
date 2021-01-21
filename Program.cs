using System;
using System.Collections.Generic;

namespace SeedData
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Location> Locations = new List<Location> {
           new Location { LocationId = 1, Name = "Front Door"},
                new Location { LocationId = 2, Name = "Back Door"},
                new Location { LocationId = 3, Name = "Family Room"},
          };

            DateTime localDate = DateTime.Now;

            DateTime eventDate = localDate.AddMonths(-6);

            Random rnd = new Random();

            List<Event> events = new List<Event>();

            while (eventDate < localDate)
            {
                int num = rnd.Next(0, 6);

                SortedList<DateTime, Event> dailyEvents = new SortedList<DateTime, Event>();

                for (int i = 0; i < num; i++)
                {
                    int hour = rnd.Next(0, 24);
                    int minute = rnd.Next(0, 60);
                    int second = rnd.Next(0, 60);
                    int loc = rnd.Next(0, Locations.Count);

                    DateTime d = new DateTime(eventDate.Year, eventDate.Month, eventDate.Day, hour, minute, second);

                    Event e = new Event { Flagged = false, Location = Locations[loc], LocationId = Locations[loc].LocationId, TimeStamp = d };

                    dailyEvents.Add(d, e);

                }

                foreach (var de in dailyEvents)
                {
                    events.Add(de.Value);
                }

                eventDate = eventDate.AddDays(1);

                foreach (Event e in events)
                {
                    Console.WriteLine($"{e.TimeStamp}, {e.Location.Name}");
                }





            }





        }
    }





}
