using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MVVMTools
{
    public abstract class ViewModelCollectionBase<TViewModel> : ViewModelBase
        where TViewModel : ViewModelBase
    {
        private ObservableCollection<TViewModel> _items;

        public ObservableCollection<TViewModel> Items
        {
            get
            {
               return _items ?? (_items = LoadItems());
            }
            set
            {
                if(_items != value)
                {
                    _items = value;
                    RaisePropertyChanged(nameof(Items));
                }
            }
        }

        private TViewModel _selectedItem;

        public TViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    RaisePropertyChanged(nameof(SelectedItem));
                }
            }
        }

        protected abstract ObservableCollection<TViewModel> LoadItems();
    }
}
