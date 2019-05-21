namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Helpers;
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

        private ObservableCollection<LandItemViewModel> lands;

        private bool isRefreshing;

        private string filter;

        #endregion Attributes

        #region Properties

        public ObservableCollection<LandItemViewModel> Lands
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
                                 Languages.Error,
                                 connection.Message,
                                 Languages.Accept);

                await App.Navigator.PopAsync();
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
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                await App.Navigator.PopAsync();
            }

            MainViewModel.GetInstance().LandsList = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<LandItemViewModel>(
                this.ToLandItemViewModel());
            this.IsRefreshing = false;
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel());
            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLandItemViewModel()
                    .Where(x => x.Name.ToLower().Contains(this.Filter.ToLower())
                        || x.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }

        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().LandsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }

        #endregion Methods

        #region Commands

        public ICommand RefreshCommand => new RelayCommand(LoadLands);

        public ICommand SearchCommand => new RelayCommand(Search);

        #endregion Commands
    }
}