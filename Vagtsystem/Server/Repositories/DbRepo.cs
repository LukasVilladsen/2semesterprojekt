using Npgsql;
using System.Data;
using Dapper;

namespace Vagtsystem.Server.Repositories
{
    public class DbRepo : IDbRepo
    {
        private readonly IDbConnection _db;

        //opretter forbindelse til databasen
        public DbRepo(IConfiguration configuration)
        {
            _db = new NpgsqlConnection("User ID=kdfszyvv;Password=4JfZi5yEDWiC_lIBh4z-M-uW-2QQLyII;Host=balarama.db.elephantsql.com;Port=5432;Database=kdfszyvv;");
        }

        //standard funktion til at hente et enkelt objekt fra database
        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;

        }

        //standard funktion til at hente liste af objekter fra database
        public async Task<List<T>> GetAll<T>(string command, object parms)
        {

            List<T> result = new List<T>();

            
                result = (await _db.QueryAsync<T>(command, parms)).ToList();
                Console.WriteLine("dbservice");

                return result;
            

        }

        //standard funktion til redigering (insert/update) af objekt i database
        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await _db.ExecuteAsync(command, parms);

            return result;
        }
    }
}
