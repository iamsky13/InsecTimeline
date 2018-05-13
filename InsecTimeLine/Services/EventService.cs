using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsecTimeLine.Controllers;
using InsecTimeLine.Models;

namespace InsecTimeLine.Services
{
    public class EventService
    {
        private readonly InsecTimelineContext _db;
        private readonly UploadService _uploadService;
        private readonly DateConvertService _dateConvertService;

        public EventService(InsecTimelineContext db, UploadService uploadService, DateConvertService dateConvertService)
        {
            _db = db;
            _uploadService = uploadService;
            _dateConvertService = dateConvertService;
        }

        public bool AddNewEvent(EventFormViewModel model)
        {
            var imageUrl = _uploadService.Upload(model.Image);

            var transaction = _db.Database.BeginTransaction();

            var @event = new Events
            {
                DateEng = model.EnglishDate,
                DateNep = model.NepaliDate
            };

            _db.Events.Add(@event);
            _db.SaveChanges();

            var timeline = new Timeline
            {
                Description = model.Description,
                EventLink = model.Link,
                Title = model.Title,
                EventRefId = @event.Id,
                ImageLink = imageUrl
            };

            _db.Timeline.Add(timeline);
            _db.SaveChanges();

            transaction.Commit();
            return true;
        }
    }
}