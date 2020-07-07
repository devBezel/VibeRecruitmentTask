using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vibe.DAL.Database.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime EstablishmentDate { get; set; }

        public List<EmployeeModel> Employees { get; set; }
    }
}
