using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FamilyTreeVeuDb.Model;

namespace FamilyTreeVueDb.Data
{
    public class PersonRepository
    {
        private string _connectionString;

        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Person> GetPerson()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"select * from personinfo where id = @Id";
                var result = await connection.QueryAsync<Person>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }



        public async Task<int> Create(Person person)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO PersonInfo (FirstName, LastName, MiddleName, PlaceOfBirth, DateOfBirth, LifeStatus)                         
                            VALUES (@FirstName, @LastName, @MiddleName, @PlaceOfBirth, @DateOfBirth, @LifeStatus)";
                return await conn.ExecuteAsync(sql, person);
            }

        }
        public async Task<int> CreateWithFatherId(Person person)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql =
                    @"INSERT INTO PersonInfo (FirstName, LastName, MiddleName, PlaceOfBirth, DateOfBirth, LifeStatus, FatherId)                         
                            VALUES (@FirstName, @LastName, @MiddleName, @PlaceOfBirth, @DateOfBirth, @LifeStatus, @FatherId)";
                return await conn.ExecuteAsync(sql, person);
            }
        }
        public async Task<int> CreateWithMotherId(Person person)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql =
                    @"INSERT INTO PersonInfo (FirstName, LastName, MiddleName, PlaceOfBirth, DateOfBirth, LifeStatus, MotherId)                         
                            VALUES (@FirstName, @LastName, @MiddleName, @PlaceOfBirth, @DateOfBirth, @LifeStatus, @MotherId)";
                return await conn.ExecuteAsync(sql, person);
            }
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT Id, FirstName, LastName, DateOfBirth
                            FROM PersonInfo";
                return await conn.QueryAsync<Person>(sql);
            }
        }

        //public async Task<IEnumerable<Person>> ReadYongerThan(int DateOfBirthMin)
        //{
        //    var sql = @"SELECT Id, FirstName, LastName, DateOfBirth
        //                    FROM PersonInfo WHERE DateOfBirth > @DateOfBirthMin";
        //    return await _connection.QueryAsync<Person>(sql, new { DateOfBirthMin = DateOfBirthMin });
        //}
        public async Task<IEnumerable<Person>> ReadOneById(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT Id, FirstName, LastName, DateOfBirth
                            FROM PersonInfo WHERE Id = @Id";
                return await conn.QueryAsync<Person>(sql, new {Id = id});
            }
        }

        public async Task<IEnumerable<Person>> ReadFamily()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"
            SELECT p.*, f.FirstName FatherFirstName
            FROM PersonInfo p
                LEFT JOIN PersonInfo f ON p.FatherId = f.Id
            WHERE p.Id = @ID
            UNION
            SELECT * , '' FatherFirstName
                FROM PersonInfo
            WHERE FatherId = @ID";

                return await conn.QueryAsync<Person>(sql);
            }
        }

        public async Task<int> Update(Person person)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE PersonInfo
                           SET LastName = @LastName, FirstName = @FirstName, DateOfBirth = @DateOfBirth
                           WHERE Id = @Id";
                return await conn.ExecuteAsync(sql, person);
            }
        }
        public async Task<int> Delete(Person person = null, int? id = null)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"Delete FROM PersonInfo
                           WHERE Id = @Id";

                return await conn.ExecuteAsync(sql, person ?? (object) new {Id = id.Value});
            }
        }
        public async Task<int> DeleteAll()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"Delete FROM PersonInfo";
                return await conn.ExecuteAsync(sql);
            }
        }
    }
}


