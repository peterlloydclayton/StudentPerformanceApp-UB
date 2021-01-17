using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPerformanceApp.Pages.FormModels
{
    public class IDSearchFormModel
    {
        [Required (ErrorMessage ="Please provide the ID")]
        public string Value { get; set; }
        [Required(ErrorMessage = "Please provide the value")]
        public string Field { get; set; }
    }
}
