using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class CourseModel
    {
        [Required(ErrorMessage = "Fyll i alla fält")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string Progression { get; set; }

        public CourseModel()
        {

        }
    }
}
