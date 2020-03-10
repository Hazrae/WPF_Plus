using ModelClient.Models;
using ModelClient.Services;
using MVVMTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using CorrectifConsoFilm.Utils;

namespace CorrectifConsoFilm.ViewModels
{
    public class FilmViewModel : ViewModelCollectionBase<DetailViewModel>
    {

        private string _titre;

        public string Titre
        {
            get { return _titre; }
            set
            {
                if(_titre != value)
                {
                    _titre = value;
                    RaisePropertyChanged(nameof(Titre));
                }
            }
        }
        private int _annee;
        public int Annee
        {
            get { return _annee; }
            set
            {
                if (_annee != value)
                {
                    _annee = value;
                    RaisePropertyChanged(nameof(Annee));
                }
            }
        }

        //private ObservableCollection<DetailViewModel> _listeFilm;

        //public ObservableCollection<DetailViewModel> ListeFilm
        //{
        //    set
        //    {
        //        if(_listeFilm != value)
        //        {
        //            _listeFilm = value;
        //            RaisePropertyChanged(nameof(ListeFilm));
        //        }
        //    }
        //    get
        //    {
        //        return _listeFilm;
        //    }
        //}

        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(Insert));
            }
        }


        

        public FilmViewModel()
        {
            GestionEvent<Film>.Instance.Register(GoDelete);
        }

        public void Insert()
        {
            Film f = new Film
            {
                Titre = Titre,
                Annee = Annee
            };

            FilmServiceClient.Instance.Insert(f);
            Items = LoadItems();
            Titre = "";
            Annee = 0;
            //Items.Add(new DetailViewModel(f));
        }

        public void GoDelete(Film f)
        {
            DetailViewModel vf = new DetailViewModel(f);
            Items = LoadItems();
           // Items.Remove(vf);
            
        }

        protected override ObservableCollection<DetailViewModel> LoadItems()
        {
            ObservableCollection<DetailViewModel> films = 
                new ObservableCollection<DetailViewModel>(FilmServiceClient.Instance.GetAll()
                .Select(x => new DetailViewModel(x)));
            return films;
        }
    }
}
