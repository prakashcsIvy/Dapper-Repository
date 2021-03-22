using Dapper;
using System.Data;
using Npgsql;

namespace DWC.DL.Common
{
    public class CommonRepository
    {
        private readonly string _connectionString;
        public CommonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
