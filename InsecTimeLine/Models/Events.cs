using System;
using System.Collections.Generic;

namespace InsecTimeLine.Models
{
    public partial class Events
    {
        public int Id { get; set; }
        public DateTime? DateEng { get; set; }
        public string DateNep { get; set; }
    }
}
