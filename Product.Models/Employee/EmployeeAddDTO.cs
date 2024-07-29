using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models.Employee
{

    public class EmployeeAddDTO
    {
        public string? EmployeeName { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public string? DateOfJoining { get; set; }

        public string? DateOfBirth { get; set; }

        public int Salary { get; set; }

        public string? CreatedBy { get; set; }

        public string? CreatedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
