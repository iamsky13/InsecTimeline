using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsecTimeLine.Models
{
    public class EventDateInfoModel
    {
        public Events Event { get; set; }
        public List<Timeline> Timelines { get; set; }

        public EventDateInfoModel GetEvents()
        {
            var db = new insectimelineContext();
            var x = (from eventData in db.Events
                join time in db.Timeline on eventData.Id equals time.EventRefId
                select new EventDateInfoModel
                {
                    Event = eventData,
                    Timelines = (from timeList in db.Timeline.Where(xy => xy.EventRefId == eventData.Id)
                                select new Timeline
                                {
                                     Id=timeList.Id,
                                     EventRefId=timeList.EventRefId,
                                     Description=timeList.Description,
                                     EventLink=timeList.EventLink,
                                     ImageLink=timeList.ImageLink,
                                     Title=timeList.Title
                                }).ToList()
                }).FirstOrDefault();
            return x;
        }

    }
}
