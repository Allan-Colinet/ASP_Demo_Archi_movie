using ASP_Demo_Archi_DAL.Models;
using ASP_Demo_Archi_DAL.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Demo_Archi_DAL.Services
{
    public class MovieService : IMovieRepo
    {
        private string connectionString = @"Data Source=GOS-VDI906\TFTIC;Initial Catalog=IMDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private Movie Converter(SqlDataReader reader)
        {
            return new Movie
            {
                Id = (int)reader["Id"],
                Title = (string)reader["Title"],
                Description = (string)reader["Description"],
                RealisatorId = (int)reader["RealisatorId"]
            };
        }

        public List<Movie> GetAll()
        {
            List<Movie> list = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Movie";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(Converter(reader));
                        }
                    }
                    connection.Close();
                }
            }
            return list;
        }

        public Movie GetById(int id)
        {
            Movie m = new Movie();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Movie WHERE Id = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            m = Converter(reader);
                        }
                    }
                    connection.Close();
                }
            }
            return m;
        }

        public bool Create(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Movie (Title, Description, RealisatorId) " +
                        "VALUES (@title, @desc, @real)";

                    cmd.Parameters.AddWithValue("title", movie.Title);
                    cmd.Parameters.AddWithValue("desc", movie.Description);
                    cmd.Parameters.AddWithValue("real", movie.RealisatorId);

                    try
                    {
                        connection.Open();
                        bool result = cmd.ExecuteNonQuery() > 0;

                        connection.Close();
                        return result; 
                    }
                    catch (SqlException ex)
                    {
                        //Gérer l'exception
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public void Edit(Movie movie)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "UPDATE Movie SET Title = @title, Description = @desc, RealisatorId = @real " +
                        "WHERE Id = @id";

                    cmd.Parameters.AddWithValue("id", movie.Id);
                    cmd.Parameters.AddWithValue("title", movie.Title);
                    cmd.Parameters.AddWithValue("desc", movie.Description);
                    cmd.Parameters.AddWithValue("real", movie.RealisatorId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM Movie WHERE Id = @id";

                    cmd.Parameters.AddWithValue("id", id);


                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<Movie> GetMovieByPersonId(int PersonId)
        {
            List<Movie> list = new List<Movie>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Movie m JOIN Movie_Person mp ON m.Id = mp.MovieId WHERE mp.PersonId = @PersonId";
                    command.Parameters.AddWithValue("PersonId", PersonId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(Converter(reader));
                        }
                    }
                    connection.Close();
                }
            }
            return list;
        }
    }
}
