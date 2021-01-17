/*
Peter Clayton, 12-04-2020
COURSE: CS652-Hadoop/NoSQL
University of Bridgeport
Master's Candidate May 2021
Department of Engineering

UserFormModel:
Purpose: Model class for the update editform element in create.razor.
Binds form data to a User object
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPerformanceApp.Pages.FormModels
{
    public class UserFormModel
    {
        [Required (ErrorMessage ="Please provide the userId")]
        [Range(100000, 999999, ErrorMessage = "Please enter a number between (10000-100000000).")]
        public long UserId { get; set; }

        [Required (ErrorMessage ="Please provide the first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide the last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide the designation")]
        public string Designation { get; set; }

        public UserFormModel()
        {
        }
    }
}
