using System;
using System.Collections.Generic;
using VirtualCable.Models;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Querying;

namespace VirtualCable.Services
{
    public class ScheduleGenerator
    {
        private readonly ILibraryManager _libraryManager;

        public ScheduleGenerator(ILibraryManager libraryManager)
        {
            _libraryManager = libraryManager;
        }

        public List<ScheduleEntry> Generate(ChannelDefinition channel)
        {
            var items = _libraryManager.GetItemList(new InternalItemsQuery
            {
                IncludeItemTypes = new[] { "Movie", "Series", "Episode" },
                Genres = string.IsNullOrEmpty(channel.Genre) ? null : new[] { channel.Genre }
            });

            var schedule = new List<ScheduleEntry>();
            var currentTime = DateTime.Now;

            foreach (var item in items)
            {
                schedule.Add(new ScheduleEntry
                {
                    ItemId = item.Id,
                    StartTime = currentTime,
                    Duration = item.RunTimeTicks ?? TimeSpan.FromMinutes(30).Ticks
                });

                currentTime = currentTime.AddTicks(item.RunTimeTicks ?? TimeSpan.FromMinutes(30).Ticks);

                if ((currentTime.Minute % channel.CommercialIntervalMinutes) == 0)
                {
                    schedule.Add(new ScheduleEntry
                    {
                        IsCommercialBlock = true,
                        Duration = TimeSpan.FromMinutes(2).Ticks
                    });
                }
            }

            return schedule;
        }
    }

    public class ScheduleEntry
    {
        public Guid ItemId { get; set; }
        public long Duration { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsCommercialBlock { get; set; }
    }
}