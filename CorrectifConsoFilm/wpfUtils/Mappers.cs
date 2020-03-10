using System;
using System.Collections.Generic;
using System.Text;
using CorrectifConsoFilm.ViewModels;
using ModelClient.Models;

namespace CorrectifConsoFilm.wpfUtils
{
    public static class Mappers
    {
        public static DetailViewModel ToViewModel(this Film f)
        {
            return new DetailViewModel
            {
                Annee = f.Annee,
                Titre = f.Titre,
                Id = f.Id
            };
        }
    }
}
