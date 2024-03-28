using projekt1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace projekt1.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand FeaturedViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }
        public DiscoveryViewModel DiscoveryVm { get; set; }
        public FeaturedViewModel FeaturedVm { get; set; }
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView;}
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }



        public MainViewModel() 
        {
            HomeVm = new HomeViewModel();
            DiscoveryVm = new DiscoveryViewModel();
            FeaturedVm = new FeaturedViewModel();
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryVm;
            });

            FeaturedViewCommand = new RelayCommand(o =>
            {
                CurrentView = FeaturedVm;
            });

        }
    }
}
