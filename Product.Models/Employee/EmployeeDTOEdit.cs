using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models.Employee
{
    public class EmployeeDTOEdit
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Mobile {  get; set; }
        public string? Email { get; set; }

       
        public DateTime? DateOfJoining { get; set; }

        
        public DateTime? DateOfBirth { get; set; }

        public int Salary { get; set; }

        public string? ModifiedBy { get; set; }

        public string? ModifiedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
