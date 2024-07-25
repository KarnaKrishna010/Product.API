using Newtonsoft.Json;
using Product.Models.Common;

namespace Product.Models.Employee
{
    public class EmployeeDTOResponse
    {
        public DataUpdateResponseDTO DataUpdateResponse { get; set; }

        public List<EmployeeDTOList> EmployeeDTOList { get; set; }

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
            status += $"EmployeeDTOList count: {this.EmployeeDTOList.Count}";
            return status;
        }

    }



    public class EmployeeDTOList
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }



}
