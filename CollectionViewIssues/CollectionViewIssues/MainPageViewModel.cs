using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollectionViewIssues
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            Refresh();
        }

        private ObservableCollection<CollectionItemModel> _items;
        public ObservableCollection<CollectionItemModel> Items
        {
            get => _items;
            set
            {
                _items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
            }
        }
        public ICommand RefreshCommand => new Command(Refresh);
        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
            }
        }

        private void Refresh()
        {
            IsRefreshing = true;
            Items = new ObservableCollection<CollectionItemModel>();
            var rd = new Random();
            var count = rd.Next(30, 50);
            for (var i = 0; i < count; i++)
            {
                var val = rd.Next(0, 1000);
                var text = i % 3 == 0 ? "1 Line" : "This has two lines";
                Items.Add(new CollectionItemModel
                {
                    Number = val,
                    Text = text
                });
            }

            IsRefreshing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
