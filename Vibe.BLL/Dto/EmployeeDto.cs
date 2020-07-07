using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vibe.BLL.Dto
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "Imie jest wymagane")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Płeć jest wymagana")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "Płaca jest wymagana")]
        public float Salary { get; set; }
    }
}
