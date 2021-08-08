using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleSchoolAPI.Models
{
    public class Classroom
    {
        public int Id { get; set; }

        [Required]
        public string ClassName { get; set; }

        [Required]
        public string ClassTeacher { get; set; }

        [Required]
        public int NumbersOfStudents { get; set; }
    }
}
