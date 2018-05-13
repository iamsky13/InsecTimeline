using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InsecTimeLine.Models
{
    public class EventFormViewModel
    {
        [Required]
        [DisplayName("Nepali Date")]
        public string NepaliDate { get; set; }

        [Required]
        [DisplayName("English Date")]
        public DateTime? EnglishDate { get; set; }

        [Required] public string Title { get; set; }

        [Required] public string Description { get; set; }

        [Required] public string Link { get; set; }
        [Required] public IFormFile Image { get; set; }
    }
}