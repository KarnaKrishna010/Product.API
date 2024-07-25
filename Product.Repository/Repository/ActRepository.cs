using Dapper;
using Product.DAL;
using Product.Models.Admin;
using Product.Models.Common;
using Product.Repository.Interface;
using System.Data;
using System.Data.SqlClient;

namespace Product.Repository.Repository
{
    public class ActRepository : IAct
    {
        private readonly AppConnectionString appConnectionString;
        public ActRepository(AppConnectionString appConnectionString)
        {
            this.appConnectionString = appConnectionString;
        }
        public ActDTOResponse List(string userName)
        {
            ActDTOResponse actDTOListResponse = new ActDTOResponse();
            using (IDbConnection cnn = new SqlConnection(appConnectionString.ConnectionString))
            {
                var result = cnn.QueryMultiple("Act_List_Admin", new { UserName = userName }, null, null, CommandType.StoredProcedure);
                if (!result.IsConsumed)
                {
                    actDTOListResponse.DataUpdateResponse = result.Read<DataUpdateResponseDTO>().FirstOrDefault();
                }
                if (actDTOListResponse.DataUpdateResponse.Status)
                {
                    if (!result.IsConsumed)
                    {
                        actDTOListResponse.ActDTOList = result.Read<ActDTOList>().ToList();
                    }
                }
            }
            return actDTOListResponse;
        }
    }
}
