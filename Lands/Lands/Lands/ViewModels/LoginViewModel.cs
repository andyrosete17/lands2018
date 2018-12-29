namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Services;

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

        public ICommand RegisterCommand { get; }

        #endregion Commands

        #region Constructors

        public LoginViewModel()
        {
            IsRemembered = true;
            IsEnable = true;
            Email = "andyrosete17@gmail.com";
            Password = "123456";
            this.apiService = new ApiService();
        }

        #endregion Constructors

        #region CommandsImplementation

        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept"
                    );
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password",
                    "Accept"
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
                    "Error",
                    connection.Message,
                    "Accept"
                    );
                return;
            }
            var token = await this.apiService.GetToken(
                "http://lands.somee.com/API/",
                this.Email,
                this.Password);

            if (token == null)
            {
                IsRunning = false;
                IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Something was wrong, please try again later...",
                    "Accept"
                    );
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunning = false;
                IsEnable = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    token.ErrorDescription,
                    "Accept"
                    );
                this.Password = string.Empty;
                return;
            }
            var mainViewModel = MainViewModel.GetInstance();

            mainViewModel.Token = token;

            /// TODO 023 De esta forma antes de pintar la lands page se establece la
            /// LandsViewmodel alineada a la vista.
            mainViewModel.Lands = new LandsViewModel();

            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            IsRunning = false;
            IsEnable = true;

            Email = string.Empty;
            Password = string.Empty;
        }

        #endregion CommandsImplementation
    }
}