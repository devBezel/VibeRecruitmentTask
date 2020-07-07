using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vibe.BLL.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Imie jest wymagane")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Data dodania jest wymagana")]
        public DateTime EstablishmentDate { get; set; }

        public List<EmployeeDto> Employees { get; set; }
    }
}
