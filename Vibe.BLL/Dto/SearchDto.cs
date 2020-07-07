using System;
using System.Collections.Generic;
using System.Text;

namespace Vibe.BLL.Dto
{
    public class SearchDto
    {
        public string Keyword { get; set; }
        public float EmployeeSalaryFrom { get; set; }
        public float EmployeeSalaryTo { get; set; }
    }
}
