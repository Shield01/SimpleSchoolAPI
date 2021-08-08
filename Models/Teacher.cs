using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSchoolAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string TeachersLastName { get; set; }

        [Required]
        public string TeachersFirstName { get; set; }

        [Required]
        public string TeachersQualification { get; set; }

        public string MaritalStatus { get; set; }

        [Required]
        public string Salary { get; set; }
    }
}
