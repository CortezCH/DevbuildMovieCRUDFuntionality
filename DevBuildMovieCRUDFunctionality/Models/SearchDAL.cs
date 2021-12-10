using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildMovieCRUDFunctionality.Models
{
    public class SearchDAL
    {
        public List<Movie> SearchMovie(Search model)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = $"SELECT * from movies where title like '%{model.Title}%' AND genre like '%{model.Genre}%' ";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();
                connect.Close();
                return movies;
            }
        }

    }
}
