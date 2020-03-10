using CorrectifConsoFilm.Utils;
using ModelClient.Models;
using ModelClient.Services;
using MVVMTools;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectifConsoFilm.ViewModels
{

    public class DetailViewModel : ViewModelBase
    {
        

        private Film _entity;

        public string Titre
        {
            get { return _entity.Titre; }
            set { _entity.Titre = value; }
            
        }

        public int Id
        {
            get { return _entity.Id; }
            set { _entity.Id = value; }
        }

        public int Annee
        {
            get { return _entity.Annee; }
            set { _entity.Annee = value; }
        }

        
        public DetailViewModel(Film f)
        {
            _entity = f;
        }

        private RelayCommand _deleteCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(Delete));
            }
        }

        private RelayCommand _detailCommand;
        public RelayCommand DetailCommand
        {
            get
            {
                return _detailCommand ?? (_detailCommand = new RelayCommand(Details));
            }
        }

        public void Delete()
        {
            
            FilmServiceClient.Instance.Delete(_entity.Id);
            GestionEvent<Film>.Instance.Send(_entity);
        }

        public void Details()
        {
            DetailWindow dw = new DetailWindow();
            dw.DataContext = this;
            
            dw.Show();
        }
    }
}
