using Newtonsoft.Json;
using Product.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Models.Employee
{
    public class EmployeeDetailDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }

        public EmployeeDetailDTO EmployeeDetailDTO { get; set; }

        public override string ToString()
        {
            if (DataUpdateResponse == null)
            {
                return $"No status available";
            }
            string status = DataUpdateResponse.ToString();
            if (this.DataUpdateResponse.Status == false)
            {
                return status;
            }
            status += $"EmployeeDetailDTO count: {this.EmployeeDetailDTO}";
            return status;
        }
    }

    public class EmployeeDetailDTO
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Salary { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedByIpAddress { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public string? ModifiedByIpAddress { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletedByIpAddress { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}
