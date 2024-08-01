using Newtonsoft.Json;
using Product.Models.Common;

namespace Product.Models.Employee
{

    public class EmployeeDeletedDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }

        public List<EmployeeDTODeletedList> EmployeeDTODeletedList { get; set; }

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
            status += $"EmployeeDTODeletedList count: {this.EmployeeDTODeletedList.Count}";
            return status;
        }

    }

    public class EmployeeDTODeletedList
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


    }


}
