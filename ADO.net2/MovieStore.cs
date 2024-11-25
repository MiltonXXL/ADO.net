using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.net2
{
    public class MovieStore
    {
        public SqlCommand GetActorFilms(SqlConnection connection)
        {
            Console.WriteLine("Välj skådespelares förnamn: ");
            string? actorFirstName = Console.ReadLine();
            Console.WriteLine("Välj skådespelares efternamn: ");
            string? actorLastName = Console.ReadLine();

            SqlCommand command = new SqlCommand($"select film.title " +
                $"                                       from actor " +
                $"                                       inner join film_actor on actor.actor_id = film_actor.actor_id" +
                $"                                       inner join film on film_actor.film_id = film.film_id" +
                $"                                       where first_name = '{actorFirstName}' " +
                $"                                       and last_name = '{actorLastName}'" +
                $"                                       ", connection);
            return command;
        }
    }
}
