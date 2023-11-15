using Backend.AppLocation.Entities;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Backend.AppLocation.DataAccess;

namespace Backend.AppLocation.Repositories
{
    public class UserRepository 
    {

        private readonly IHelper _helper;
        

        public UserRepository(IHelper helper)
        {
            _helper = helper;
        }

        public UserRepository()
        {
        }

        private String _connectionString;
        private String connectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_connectionString))
                    _connectionString = _helper.GetConnectionString();

                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        public User GetUserById(int id)
        {
            connectionString = _helper.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "get_UserById"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();
                var reader = command.ExecuteReader();
                return reader.Read() ? DataReaderToUser(reader) : null;
            }
        }

        public User GetUserByUserOrEmail(string param,String connString)
        {
            //var cs = _helper.Pruebas();
            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "get_UserByUserNameEmail"
                };
                command.Parameters.Add(new SqlParameter("@UserNameOrEmail", param));

                connection.Open();
                var reader = command.ExecuteReader();
                return reader.Read() ? DataReaderToUser(reader) : null;
            }
        }

        public List<User> GetAllUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "get_AllUsers"
                };

                connection.Open();
                var reader = command.ExecuteReader();
                var users = new List<User>();
                while (reader.Read())
                {
                    users.Add(DataReaderToUser(reader));
                }
                return users;
            }
        }

        private static User DataReaderToUser(SqlDataReader reader)
        {
            return new User
            {
                Id = (Int64)reader["Id"],
                Name = reader["Name"].ToString(),
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString(),
                Username = reader["Username"].ToString()
            };
        }

        public User CreateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "insert_User"
                };
                command.Parameters.Add(new SqlParameter("@Name", user.Name));
                command.Parameters.Add(new SqlParameter("@Email", user.Email));
                command.Parameters.Add(new SqlParameter("@Password", user.Password));
                command.Parameters.Add(new SqlParameter("@Username", user.Username));

                connection.Open();
                var reader = command.ExecuteReader();
                return reader.Read() ? DataReaderToUser(reader) : null;
            }
        }

        public User UpdateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "upd_User"
                };
                command.Parameters.Add(new SqlParameter("@Id", user.Id));
                command.Parameters.Add(new SqlParameter("@Name", user.Name));
                command.Parameters.Add(new SqlParameter("@Email", user.Email));
                command.Parameters.Add(new SqlParameter("@Password", user.Password));
                command.Parameters.Add(new SqlParameter("@Username", user.Username));

                connection.Open();
                var reader = command.ExecuteReader();
                return reader.Read() ? DataReaderToUser(reader) : null;
            }
        }

        public bool DeleteUser(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "delete_User"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();
                var rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}