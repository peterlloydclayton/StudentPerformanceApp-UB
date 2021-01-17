/*
Peter Clayton, 12-04-2020
COURSE: CS652-Hadoop/NoSQL
University of Bridgeport
Master's Candidate May 2021
Department of Engineering

UpdateFormModel:
Purpose: Model class for the update editform element in update.razor.
Binds form data to a User object
*/

using System.ComponentModel.DataAnnotations;

namespace StudentPerformanceApp.Pages.FormModels
{
    public class UpdateFormModel
    {
        [Required(ErrorMessage = "Please provide the record field to filter")]

        public string filterKey { get; set; }

        [Required(ErrorMessage = "Please provide the record field criteria to filter")]

        public string filterValue { get; set; }

        [Required(ErrorMessage = "Please provide the field to update")]

        public string updateKey { get; set; }

        [Required(ErrorMessage = "Please provide the new value")]

        public string updateValue { get; set; }

        public UpdateFormModel()
        {
        }
    }
}
