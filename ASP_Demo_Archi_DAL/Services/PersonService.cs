using ASP_Demo_Archi_DAL.Models;
using ASP_Demo_Archi_DAL.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Demo_Archi_DAL.Services
{
    public class PersonService : IPersonRepo
    {
        private string connectionString = @"Data Source=GOS-VDI906\TFTIC;Initial Catalog=IMDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        private Person Converter(SqlDataReader reader)
        {
            return new Person
            {
                Id = (int)reader["Id"],
                Lastname = (string)reader["Lastname"],
                Firstname = (string)reader["Firstname"],
                PictureURL = (string)reader["PictureURL"]
            };
        }
        public List<Person> GetAll()
        {
            List<Person> listPerson = new List<Person>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Person";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listPerson.Add(Converter(reader));
                        }
                    }
                    connection.Close();
                }
            }
            return listPerson;
        }
        public Person GetById(int Id)
        {
            Person person = new Person();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Person WHERE Id = @Id";
                    command.Parameters.AddWithValue("Id", Id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            person = (Converter(reader));
                        }
                    }
                    connection.Close();
                }
            }
            return person;
        }

        public void Create(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Person (Lastname, Firstname, PictureURL) VALUES (@Lastname, @Firstname, @PictureUrl)";

                    command.Parameters.AddWithValue("Lastname", person.Lastname);
                    command.Parameters.AddWithValue("Firstname", person.Firstname);
                    command.Parameters.AddWithValue("PictureURL", person.PictureURL);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

    }
}
