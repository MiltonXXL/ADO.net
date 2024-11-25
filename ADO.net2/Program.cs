using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.SqlTypes;

namespace ADO.net2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieStore store = new MovieStore();

            SqlConnection? connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sakila;" +
                                                                        "Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
                                                                        "Trust Server Certificate=False;Application Intent=ReadWrite;" +
                                                                        "Multi Subnet Failover=False");
            SqlCommand command = store.GetActorFilms(connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("Aktuella filmer: ");
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }
            connection.Close();
        }
    }
}
