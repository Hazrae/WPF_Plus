using ModelGlobal.Data;
using ModelGlobal.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ModelGlobal.Services
{
    public class FilmService : IFilmRepository<Film>
    {
        private static IFilmRepository<Film> _instance;

        public static IFilmRepository<Film> Instance
        {
            get { return _instance ?? (_instance = new FilmService());  }
        }

        private SqlConnection _connection;
        private FilmService()
        {
            _connection = new SqlConnection(@"Data Source=DESKTOP-RGPQP6I\TFTIC2014;Initial Catalog=ExoWPF;User ID=sa;Password=steve1983");
            _connection.Open();
        }

        public void Delete(int id)
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "Delete FROM Film WHERE Id = @id";
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Film> GetAll()
        {
            using(SqlCommand cmd = _connection.CreateCommand())
            {
                List<Film> f = new List<Film>();
                cmd.CommandText = "SELECT * FROM Film";
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        f.Add(new Film
                        {
                            Id = (int)dr["Id"],
                            Titre = dr["Titre"].ToString(),
                            Annee = (int)dr["AnneeDeSortie"]
                        });
                    }
                }
                return f;
            }
        }

        public Film GetOne(int id)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                Film f = new Film();
                cmd.CommandText = "SELECT * FROM Film";
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        f.Id = (int)dr["Id"];
                        f.Titre = dr["Titre"].ToString();
                        f.Annee = (int)dr["AnneeDeSortie"];  
                    }
                }
                return f;
            }
        }

        public void Insert(Film t)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Film (Titre, AnneeDeSortie) VALUES (@titre, @annee)";
                cmd.Parameters.AddWithValue("titre", t.Titre);
                cmd.Parameters.AddWithValue("annee", t.Annee);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Film t)
        {
            using (SqlCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE Film SET Titre = @titre, AnneeDeSortie = @Annee WHERE Id = @id";
                cmd.Parameters.AddWithValue("titre", t.Titre);
                cmd.Parameters.AddWithValue("annee", t.Annee);
                cmd.Parameters.AddWithValue("id", t.Id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
