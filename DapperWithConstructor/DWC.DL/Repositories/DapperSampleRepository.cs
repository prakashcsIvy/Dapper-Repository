using Dapper;
using DWC.DL.Common;
using DWC.Models.Models;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DWC.DL.Repositories
{
    public interface IDapperSampleRepository
    {
        int Insert();
        int Update(int categoryId = 2);
        int UpdateDynamicParam();
        long GetProductsCount();
        int Delete();
        List<SADM_Users> GetAllUsers();
        Task<SADM_Users> GetByID(int id);
    }

    public class DapperSampleRepository : IDapperSampleRepository
    {
        private readonly IOptions<DBSection> _dBSection;

        public DapperSampleRepository(IOptions<DBSection> dBSection)
        {
            _dBSection = dBSection;
        }

        //Execute
        public int Insert()
        {
            int affectedRows;
            var sql = "insert into products (ProductName) values ('Pampers 3xl')";
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                using (var t = Con.BeginTransaction())
                {
                    affectedRows = Con.Execute(sql);

                    t.Commit();
                }
            }
            return affectedRows;
        }

        //Parameter Anonymous 
        public int Update(int categoryId = 2)
        {
            int updatedRows;
            var sql = @"update products set unitprice = unitprice *.1 where CategoryId = @categoryid";
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                updatedRows = Con.Execute(sql, new { CategoryId = categoryId });
            }
            return updatedRows;
        }

        //Dynamic Parameters
        public int UpdateDynamicParam()
        {
            var parameters = new DynamicParameters();
            var customerId = "AL2435";
            parameters.Add("@CustomerId", customerId, DbType.String, ParameterDirection.Input, customerId.Length);
            int updatedRows;
            var sql = @"update products set unitprice = unitprice *.1 where CategoryId = @categoryid";
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                updatedRows = Con.Execute(sql, parameters);
            }
            return updatedRows;
        }

        public int Delete()
        {
            int deletedRows;
            var sql = "delete from categories where CategoryName = 'New Category'";
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                deletedRows = Con.Execute(sql);
            }
            return deletedRows;
        }

        //ExecuteScalar
        public long GetProductsCount()
        {
            int count;
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                var sql = "select count(*) from products";
                count = Con.ExecuteScalar<int>(sql);
            }
            return count;
        }

        //Query
        public List<SADM_Users> GetAllUsers()
        {
            List<SADM_Users> obj = new List<SADM_Users>();
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                string query = $"select * from \"SADM_Users\" where ID=@id";
                obj = Con.Query<SADM_Users>(query).ToList();
            }
            return obj;
        }

        //QueryAsync
        public async Task<SADM_Users> GetByID(int id=10)
        {
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                string sQuery = "SELECT ID, FirstName, LastName, DateOfBirth FROM from \"SADM_Users\" WHERE ID = @ID";
                var result = await Con.QueryAsync<SADM_Users>(sQuery, new { ID = id });
                return result.FirstOrDefault();
            }
        }

        //QuerySingleAsync
        public async Task<dynamic> GetByIDQuerySingleAsync(int id = 1)
        {
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                var sql = "select * from products where productid = @ID";
                return await Con.QuerySingleAsync(sql, new { ID = id });
            }
        }

        //QuerySingle
        public SADM_Users GetRosterByTeamID(int teamId)
        {
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                return Con.QuerySingle<SADM_Users>("SELECT * FROM SADM_Users WHERE ID = @id", new { id = teamId });
            }
        }

        //QueryMultiple
        public ProductsDataModel GetAgencies(int organizationId)
        {
            ProductsDataModel DataModel = new ProductsDataModel();
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                using (var multi = Con.QueryMultiple("SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID; SELECT * FROM InvoiceItem WHERE InvoiceID = @InvoiceID;"))
                {
                    var Country = multi.Read<Invoice>().ToList();
                    var State = multi.Read<InvoiceItem>().ToList();
                }
                return DataModel;
            }
        }

        //BeginTransaction
        public int Insertcategories(int organizationId)
        {
            int affectedRows;
            var sql = "insert into categories (CategoryName) values ('New Category')";
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                using (var t = Con.BeginTransaction())
                {
                    try
                    {

                        affectedRows = Con.Execute(sql);
                        t.Commit();
                    }
                    catch
                    {
                        t.Rollback();
                    }
                }

            }
            return affectedRows;
        }

        //Stored Procedures
        public List<AccessDetailsDataModel> GetAccess(int organizationId, string vendorIds, string ids)
        {
            List<AccessDetailsDataModel> result = new List<AccessDetailsDataModel>();
            using (IDbConnection Con = new NpgsqlConnection(_dBSection.Value.DefaultConnection))
            {
                result = Con.Query<AccessDetailsDataModel>("usp_GetAccessCardDetails", new { OrganizationId = organizationId, VendorIds = vendorIds, Ids = ids }, commandType: CommandType.StoredProcedure).ToList();
            }
            return result ?? new List<AccessDetailsDataModel>();
        }
    }
}

