using Dapper;
using DWC.DL.Common;
using DWC.Models.Models;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DWC.DL.Repositories
{
    public interface IDapperSampleRepository {
        List<SADM_Users> sample();
    }

    public class DapperSampleRepository : IDapperSampleRepository
    {
        private readonly IOptions<DBSection> _dBSection;

        public DapperSampleRepository(IOptions<DBSection> dBSection)
        {
            _dBSection = dBSection;
        }

        public List<SADM_Users> sample()
        {
            List<SADM_Users> obj = new List<SADM_Users>();
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                string query = $"select * from \"Appdata_Order_Header\"";
                obj = Con.Query<SADM_Users>(query).ToList();
            }
            return obj;
        }

        public List<SADM_Users> sample(int id=10)
        {
            List<SADM_Users> obj = new List<SADM_Users>();
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                string query = $"select * from \"Appdata_Order_Header\"";
                obj = Con.Query<SADM_Users>(query).ToList();
            }
            return obj;
        }
    }
}
