using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Demo_Archi_DAL.Services
{
    public class Movie_PersonService
    {
        private string connectionString = @"Data Source=GOS-VDI906\TFTIC;Initial Catalog=IMDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public void AddRole(int MovieId, int PersonId, string Role)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Movie_Person (PersonId,MovieId, Role) VALUES (@PersonId, @MovieId, @Role)";

                    command.Parameters.AddWithValue("PersonId", PersonId);
                    command.Parameters.AddWithValue("MovieId", MovieId);
                    command.Parameters.AddWithValue("Role", Role);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
