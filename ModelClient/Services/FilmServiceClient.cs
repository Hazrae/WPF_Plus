using ModelClient.Models;
using ModelGlobal.Repositories;
using G = ModelGlobal.Data;
using GS = ModelGlobal.Services;
using ModelClient.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ModelClient.Services
{
    public class FilmServiceClient : IFilmRepository<Film>
    {
        private static IFilmRepository<Film> _instance;
        private IFilmRepository<G.Film> _GlobalService; 

        public static IFilmRepository<Film> Instance
        {
            get { return _instance ?? (_instance = new FilmServiceClient()); }
        }

        private FilmServiceClient()
        {
            _GlobalService = GS.FilmService.Instance;
        }


        public void Delete(int id)
        {
            _GlobalService.Delete(id);
        }

        public List<Film> GetAll()
        {
            return _GlobalService.GetAll().Select(x => x.ToLocal()).ToList();
        }

        public Film GetOne(int id)
        {
            return _GlobalService.GetOne(id).ToLocal();
        }

        public void Insert(Film t)
        {
            _GlobalService.Insert(t.ToGlobal());
        }

        public void Update(Film t)
        {
            _GlobalService.Update(t.ToGlobal());
        }
    }
}
