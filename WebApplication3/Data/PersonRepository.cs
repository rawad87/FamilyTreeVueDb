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

        public async Task<Person> GetPerson(int id) //Fetches Single Person from DB table personinfo using Id
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"select * from PersonInfo where id = @Id";
                var result = await connection.QueryAsync<Person>(sql, new { Id = id });
                return result.FirstOrDefault();
            }
        }
        public async Task<IEnumerable<Person>> ReadAll() //Fetches every person in the DB table personinfo
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT *
                            FROM PersonInfo";
                return await conn.QueryAsync<Person>(sql);
            }
        }


        public async Task<int> Create(Person person) //Creates a new user in DB table personinfo, using info from client.
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO PersonInfo (FirstName, LastName, MiddleName, PlaceOfBirth, DateOfBirth, LifeStatus, FatherId, MotherId)                         
                            VALUES (@FirstName, @LastName, @MiddleName, @PlaceOfBirth, @DateOfBirth, @LifeStatus, @FatherId, @MotherId)";
                return await conn.ExecuteAsync(sql, person);
            }

        }

        public async Task<IEnumerable<Person>> ReadFamily(int fatherId, int id) //Fetches a family by fatherId from DB table personinfo
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"
                                SELECT p.*, f.FirstName FatherFirstName
                                FROM PersonInfo p
                                    LEFT JOIN PersonInfo f ON p.FatherId = f.Id
                                WHERE p.Id = @id
                                UNION
                                SELECT * , '' FatherFirstName
                                    FROM PersonInfo
                                WHERE FatherId = @id";
                return await conn.QueryAsync<Person>(sql, (fatherId, id));
            }
        }

        public async Task<int> Update(Person person) //Updates a person in DB table personinfo by info from client, based on Id provided by client.
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE PersonInfo
                           SET LastName = @LastName, FirstName = @FirstName, DateOfBirth = @DateOfBirth
                           WHERE Id = @Id";
                return await conn.ExecuteAsync(sql, person);
            }
        }
        public async Task<int> Delete(Person person = null, int? id = null) //Removes a person from DB table personinfo using Id.
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"Delete FROM PersonInfo
                           WHERE Id = @Id";

                return await conn.ExecuteAsync(sql, person ?? (object) new {Id = id.Value});
            }
        }
        public async Task<int> DeleteAll() //Removes all people in DB table personinfo, DO NOT USE!!!
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = @"Delete FROM PersonInfo";
                return await conn.ExecuteAsync(sql);
            }
        }
        //public async Task<IEnumerable<Person>> ReadYongerThan(int DateOfBirthMin)
        //{
        //    var sql = @"SELECT Id, FirstName, LastName, DateOfBirth
        //                    FROM PersonInfo WHERE DateOfBirth > @DateOfBirthMin";
        //    return await _connection.QueryAsync<Person>(sql, new { DateOfBirthMin = DateOfBirthMin });
        //}
    }
}


