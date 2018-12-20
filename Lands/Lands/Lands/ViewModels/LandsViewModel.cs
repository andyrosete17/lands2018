namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        #region Services

        private readonly ApiService apiService;

        #endregion Services

        #region Attributes

        private ObservableCollection<Land> lands;
        private bool isRefreshing;
        private string filter;
        private List<Land> landsList;

        #endregion Attributes

        #region Properties

        public ObservableCollection<Land> Lands
        {
            get => this.lands;
            set => SetValue(ref this.lands, value);
        }

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => SetValue(ref this.isRefreshing, value);
        }

        public string Filter
        {
            get => this.filter;
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }

        #endregion Properties

        #region Constructors

        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }

        #endregion Constructors

        #region Methods

        private async void LoadLands()
        {
            this.IsRefreshing = true;
            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                                   "Error",
                                   connection.Message,
                                   "Accept");

                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var response = await apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            this.landsList = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(landsList);
            this.IsRefreshing = false;
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<Land>(
                    this.landsList);
            }
            else
            {
                this.Lands = new ObservableCollection<Land>(
                    this.landsList
                    .Where(x => x.Name.ToLower().Contains(this.Filter.ToLower())
                        || x.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }

        #endregion Methods

        #region Commands

        public ICommand RefreshCommand => new RelayCommand(LoadLands);

        public ICommand SearchCommand => new RelayCommand(Search);

        #endregion Commands
    }
}