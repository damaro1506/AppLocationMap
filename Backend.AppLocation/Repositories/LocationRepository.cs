using Backend.AppLocation.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Backend.AppLocation.Repositories
{
    public class LocationRepository
    {
        private readonly string _connectionString;

        public LocationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LocationRepository()
        {
        }

        public Location GeLocationById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "get_LocationById"
                };
                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();
                var reader = command.ExecuteReader();
                return reader.Read() ? DataReaderToLocation(reader) : null;
            }
        }

        public List<Location> GetAlLocations()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "get_AllLocations"
                };

                connection.Open();
                var reader = command.ExecuteReader();
                var locations = new List<Location>();
                while (reader.Read())
                {
                    locations.Add(DataReaderToLocation(reader));
                }
                return locations;
            }
        }

        private static Location DataReaderToLocation(SqlDataReader reader)
        {
            return new Location
            {
                Id = reader.GetInt64("Id"),
                FsqId = reader["Fsq_Id"].ToString(),
                Name = reader["Name"].ToString(),
                Adress = reader["Adress"].ToString(),
                Latitude = reader["Latitude"].ToString(),
                Longitude = reader["Longitude"].ToString()
            };
        }

            public Location InsertLocation(Location location)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "insert_Location"
                    };
                    command.Parameters.Add(new SqlParameter("@Fsq_Id", location.FsqId));
                    command.Parameters.Add(new SqlParameter("@Name", location.Name));
                    command.Parameters.Add(new SqlParameter("@Adress", location.Adress));
                    command.Parameters.Add(new SqlParameter("@Latitude", location.Latitude));
                    command.Parameters.Add(new SqlParameter("@Longitude", location.Longitude));
                

                    connection.Open();
                    var reader = command.ExecuteReader();
                    return reader.Read() ? DataReaderToLocation(reader) : null;
                }
            }

            public Location UpdateLocation(Location location)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "upd_Location"
                    };
                    command.Parameters.Add(new SqlParameter("@Fsq_Id", location.FsqId));
                    command.Parameters.Add(new SqlParameter("@Name", location.Name));
                    command.Parameters.Add(new SqlParameter("@Adress", location.Adress));
                    command.Parameters.Add(new SqlParameter("@Latitude", location.Latitude));
                    command.Parameters.Add(new SqlParameter("@Longitude", location.Longitude));

                    connection.Open();
                    var reader = command.ExecuteReader();
                    return reader.Read() ? DataReaderToLocation(reader) : null;
                }
            }

            public bool DeleteLocation(int id)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "delete_Location"
                    };
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    connection.Open();
                    var rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
    }
}

