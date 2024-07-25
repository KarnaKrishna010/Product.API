using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DAL
{
    public class AppConnectionString
    {
        public string ConnectionString { get; }
        public AppConnectionString(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
