using Dapper;
using Product.DAL;
using Product.Models.Common;
using Product.Models.Employee;
using Product.Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Product.Repository.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly AppConnectionString appConnectionString;

        public EmployeeRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }

        public EmployeeDTOResponse List(string username)
        {
            EmployeeDTOResponse employeeDTOListResponse = new EmployeeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Employee_List_Admin", new { UserName = username }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    employeeDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }

                if (employeeDTOListResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        employeeDTOListResponse.EmployeeDTOList = result.Read<EmployeeDTOList>().ToList();
                    }
                }
            }
            return employeeDTOListResponse;
        }

    }
}
