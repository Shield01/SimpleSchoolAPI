using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSchoolAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string StudentFirstName { get; set; }

        [Required]
        public string StudentLastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        public string Height { get; set; }
    }
}
