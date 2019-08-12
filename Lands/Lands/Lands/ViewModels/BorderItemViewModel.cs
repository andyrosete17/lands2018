namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Helpers;
    using Lands.Models;
    using Lands.Views;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class BorderItemViewModel : Border
    {
        #region Commands

        public ICommand NavigateToCountryCommand => new RelayCommand(GoToCountry);

        #endregion Commands

        #region Methods

        private async void GoToCountry()
        {
            var Land = MainViewModel.GetInstance().LandsList.Where(x => x.Name == this.Name).FirstOrDefault();
            if (Land != null)
            {
                MainViewModel.GetInstance().Land = new LandViewModel(Land);
                await App.Navigator.PopAsync();
                await App.Navigator.PushAsync(new LandTabbedPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert
                    (Languages.BorderNotFoundError,
                     Languages.CountryBorderError,
                     Languages.Accept);
            }
        }

        #endregion Methods
    }
}