using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBuildMovieCRUDFunctionality.Models
{
    public class MovieDAL
    {
        public void CreateMovie(Movie model)
        {
            

            using(var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = $"insert into movies values" +
                $"({model.ID}," +
                $" {model.Title}," +
                $" {model.Genre}," +
                $" {model.Year}," +
                $" {model.RunTime})";
                connect.Open();
                connect.Query<Movie>(sql);
                connect.Close();
            }

        }

        public List<Movie> GetMovies()
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = "SELECT * from movies";
                connect.Open();
                List<Movie> movies = connect.Query<Movie>(sql).ToList();
                connect.Close();
                return movies;
            }
        }

        public Movie GetMovie(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = $"SELECT * from movies where id = {id}";
                connect.Open();
                Movie movies = connect.Query<Movie>(sql).First();
                connect.Close();
                return movies;
            }
        }


        public void DeleteMovie(Movie model)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = $"delete from movies " +
                    $"WHERE " +
                $" id = {model.ID} AND" +
                $" title = {model.Title} AND" +
                $" genre = {model.Genre} AND" +
                $" `year` = {model.Year} AND" +
                $" runtime = {model.RunTime}";
                connect.Open();
                connect.Query<Movie>(sql);
                connect.Close();
            }

        }

        public void DeleteMovie(int id)
        {
            using (var connect = new MySqlConnection(Secret.Connection))
            {
                var sql = $"delete from movies " +
                    $"WHERE " +
                $" id = {id},";
                connect.Open();
                connect.Query<Movie>(sql);
                connect.Close();
            }

        }

    }
}
