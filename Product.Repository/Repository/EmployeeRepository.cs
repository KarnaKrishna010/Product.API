using Dapper;
using Product.DAL;
using Product.Models.Common;
using Product.Models.Employee;
using Product.Repository.Interface;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

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
            EmployeeDTOResponse response = new EmployeeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Employee_List_Admin", new { UserName = username }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }

                if (response.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        response.EmployeeDTOList = result.Read<EmployeeDTOList>().ToList();
                    }
                }
            }
            return response;
        }

        public EmployeeDeletedDTOResponse DeletedList(string username)
        {
            EmployeeDeletedDTOResponse response = new EmployeeDeletedDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Employee_DeletedList_Admin", new { UserName = username }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }

                if (response.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        response.EmployeeDTODeletedList = result.Read<EmployeeDTODeletedList>().ToList();
                    }
                }

            }

            return response;
        }

        public EmployeeDetailDTOResponse GetByCode(int employeeId, string username)
        {
            EmployeeDetailDTOResponse response = new EmployeeDetailDTOResponse();

            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                // Execute the stored procedure
                var result = cnn.QueryMultiple("Employee_GetByCode_Admin", new { EmployeeID = employeeId, UserName = username, Mode = 0 }, null, null, CommandType.StoredProcedure);

                // Read and set the DataUpdateResponse
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }

                // Check the status and read the single EmployeeDetailDTO
                if (response.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        var employeeDetailList = result.Read<EmployeeDetailDTO>().ToList();

                        // Assuming the result returns a single employee detail
                        response.EmployeeDetailDTO = employeeDetailList.FirstOrDefault();
                    }
                }
            }

            return response;
        }


        public EmployeeDTOResponse Delete(int employeeId,string deletedBy,string deletedByIpAddress)
        {
            EmployeeDTOResponse response = new EmployeeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<EmployeeDTOResponse>("Employee_Delete_Admin", new { EmployeeId = employeeId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }


        public EmployeeDTOResponse Insert(EmployeeDTOAdd employeeAddDTO)
        {
            EmployeeDTOResponse response = new EmployeeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Employee_Insert_Admin", employeeAddDTO, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (response.DataUpdateResponse.Status)
                {
                    response.EmployeeDTOList = result.Read<EmployeeDTOList>().ToList();
                }
            }
            return response;
        }

        public EmployeeDTOResponse Update(EmployeeDTOEdit employeeEditDTO)
        {
            EmployeeDTOResponse response = new EmployeeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Employee_Update_Admin", employeeEditDTO, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    response.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (response.DataUpdateResponse.Status)
                {
                    response.EmployeeDTOList = result.Read<EmployeeDTOList>().ToList();
                }
            }
            return response;

        }
    }
}
