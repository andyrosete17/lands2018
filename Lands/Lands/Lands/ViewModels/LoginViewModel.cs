namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Helpers;
    using Lands.Models;
    using Lands.Views;
    using Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Services

        private readonly ApiService apiService;

        #endregion Services

        #region Properties

        public bool IsRemembered { get; set; }

        public string Email
        {
            get => email;
            set => SetValue(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetValue(ref password, value);
        }

        public bool IsRunning
        {
            get => isRunning;
            set => SetValue(ref isRunning, value);
        }

        public bool IsEnable
        {
            get => isEnable;
            set => SetValue(ref isEnable, value);
        }

        #endregion Properties

        #region Attributes

        private string email;

        private string password;

        private bool isRunning;

        private bool isEnable;

        #endregion Attributes

        #region Commands

        public ICommand LoginCommand => new RelayCommand(Login);

        public ICommand RegisterCommand => new RelayCommand(Register);

       

        #endregion Commands

        #region Constructors

        public LoginViewModel()
        {
            IsRemembered = true;
            IsEnable = true;
            Email = "andyrosete17@gmail.com";
            Password = "123456";
            this.apiService = new ApiService();
            //this.dataService = new DataService();
        }

        #endregion Constructors

        #region CommandsImplementation

        private async void Login()
        {

            List<int> listStringVals = (new int[] { 7, 13, 8, 12, 10, 11, 14 }).ToList();
            List<int> SortedList = listStringVals.OrderBy(c => c).ToList();
            List<int> Gaps = Enumerable.Range(SortedList.First(),
                                              SortedList.Last() - SortedList.First() + 1)
                                            .Except(SortedList).ToList();
            var z = Gaps.Select(x => x.ToString()).ToList();

            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept
                    );
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept
                    );
                return;
            }

            IsRunning = true;
            IsEnable = false;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                return;
            }

            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var token = await this.apiService.GetToken(
                apiSecurity,
                this.Email,
                this.Password);

            if (token == null)
            {
                IsRunning = false;
                IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.GenericErrorValidation,
                    Languages.Accept
                    );
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunning = false;
                IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    token.ErrorDescription,
                    Languages.Accept
                    );
                this.Password = string.Empty;
                return;
            }

            var user = await this.apiService.GetUserByEmail(
                apiSecurity, 
                "api", 
                "/Users/GetUserByEmail", 
                token.TokenType, 
                token.AccessToken, 
                this.Email);

            var userLocal = Converter.ToUserLocal(user);

            var mainViewModel = MainViewModel.GetInstance();

            //Copiar token para la mainViewModel pero además para 
            mainViewModel.Token = token.AccessToken;
            mainViewModel.TokenType = token.TokenType;
            mainViewModel.User = userLocal;

            if (this.IsRemembered)
            {
                Settings.Token = token.AccessToken;
                Settings.TokenType = token.TokenType;
                //Borramos los datos que haya y se genera el nuevo usuario
                //this.dataService.DeleteAllAndInsert(userLocal);
                //Save Local User in SQLite
                using (var conn = new SQLite.SQLiteConnection(App.root_db))
                {
                    conn.CreateTable<UserLocal>();
                    conn.DeleteAll<UserLocal>();
                    conn.Insert(userLocal);
                }
            }

            /// TODO 023 De esta forma antes de pintar la lands page se establece la
            /// LandsViewmodel alineada a la vista.
            mainViewModel.Lands = new LandsViewModel();

            Application.Current.MainPage = new MasterPage();

            IsRunning = false;
            IsEnable = true;

            Email = string.Empty;
            Password = string.Empty;
        }

        private async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
        #endregion CommandsImplementation
    }
}