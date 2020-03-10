using System;
using System.Collections.Generic;
using System.Text;
using G = ModelGlobal.Data;
using C = ModelClient.Models;

namespace ModelClient.Utils
{
    public static class Mappers
    {
        public static C.Film ToLocal(this G.Film f)
        {
            return new C.Film
            {
                Id = f.Id,
                Titre = f.Titre,
                Annee = f.Annee
            };
        }

        public static G.Film ToGlobal(this C.Film f)
        {
            return new G.Film
            {
                Id = f.Id,
                Titre = f.Titre,
                Annee = f.Annee
            };
        }
    }
}
