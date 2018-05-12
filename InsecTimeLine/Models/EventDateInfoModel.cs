using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsecTimeLine.Models
{
    public class EventDateInfoModel
    {
        enum NepaliMonth
        {
            Baisakh=1,
            Jestha,
            Asar,
            Shrawan,
            Bhadra,
            Asoj,
            Kartik,
            Mangsir,
            Poush,
            Magh,
            Falgun,
            Chaitra
        }

        public Events Event { get; set; }
        public List<Timeline> Timelines { get; set; }
        public string NepMonth { get; set; }
        public List<EventDateInfoModel> GetEvents()
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
                                }).ToList(),
                    
                }).ToList();
             var res= x.GroupBy(y => y.Event).Select(g => g.First()).ToList();
            foreach (var item in res)
            {
                item.NepMonth = Enum.GetName(typeof(NepaliMonth), Convert.ToInt32(item.Event.DateNep.Split('-')[1]));
            }

            return res;

        }

    }
}
