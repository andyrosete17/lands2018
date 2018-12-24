namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
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
                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert
                    ("No Border Found",
                    "This country has no borders",
                    "Close");
            }
        }

        #endregion Methods
    }
}