using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Vibe.DAL.Database.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public CompanyModel Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public float Salary { get; set; }

    }
}
