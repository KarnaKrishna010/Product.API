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

        public EmployeeDTOResponse DeletedList(string username)
        {
            EmployeeDTOResponse response = new EmployeeDTOResponse();
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
                        response.EmployeeDTOList = result.Read<EmployeeDTOList>().ToList();
                    }
                }

            }

            return response;
        }

        public EmployeeDTOResponse GetByCode(int employeeId, string username)
        {
            EmployeeDTOResponse response = new EmployeeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Employee_GetByCode_Admin", new { EmployeeID = employeeId, UserName = username, Mode = 0 }, null, null, CommandType.StoredProcedure);
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

        public EmployeeDTOResponse Delete(int employeeId,string deletedBy,string deletedByIpAddress)
        {
            EmployeeDTOResponse response = new EmployeeDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                return cnn.Query<EmployeeDTOResponse>("Employee_Delete_Admin", new { EmployeeId = employeeId, DeletedBy = deletedBy, DeletedByIpAddress = deletedByIpAddress }, null, false, null, CommandType.StoredProcedure).FirstOrDefault();
            }
        }


        public EmployeeDTOResponse Insert(EmployeeAddDTO employeeAddDTO)
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

        public EmployeeDTOResponse Update(EmployeeEditDTO employeeEditDTO)
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
