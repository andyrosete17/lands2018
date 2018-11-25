namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        #region Services

        private ApiService apiService;

        #endregion Services

        #region Attributes

        private ObservableCollection<Land> lands;
        private bool isRefreshing;

        #endregion Attributes

        #region Properties

        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
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
            var response = await this.apiService.GetList<Land>(
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

            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
            this.IsRefreshing = false;
        }

        #endregion Methods

        #region Commands

        public ICommand RefreshCommand
        {
            get { return new RelayCommand(LoadLands);}
        }

        #endregion Commands
    }
}