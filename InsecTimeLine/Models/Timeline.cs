using System;
using System.Collections.Generic;

namespace InsecTimeLine.Models
{
    public partial class Timeline
    {
        public int Id { get; set; }
        public string EventLink { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string Title { get; set; }
        public int? EventRefId { get; set; }
    }
}
