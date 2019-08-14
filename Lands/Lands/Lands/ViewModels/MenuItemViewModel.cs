
namespace Lands.ViewModels
{

    using GalaSoft.MvvmLight.Command;
    using Lands.Helpers;
    using Lands.Models;
    using Lands.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion
        
        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
                }

        #endregion
        private void Navigate()
        {
            if (this.PageName == "LoginPage")
            {
                //Al deslogueartse se quita la persistencia.- tanto de settings como de la main viewModel
                Settings.Token = string.Empty;
                Settings.TokenType = string.Empty;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = string.Empty;
                mainViewModel.TokenType = string.Empty;
                Application.Current.MainPage = new NavigationPage(new LoginPage());
                using (var conn = new SQLite.SQLiteConnection(App.root_db))
                {
                    conn.DeleteAll<UserLocal>();
                }
            }
        }

    }
}
