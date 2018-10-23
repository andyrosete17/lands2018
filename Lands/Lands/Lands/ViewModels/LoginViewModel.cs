
namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Properties
        public string Email {get;set;}
        public bool IsRemembered { get; set; }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsEnable
        {
            get { return this.isEnable; }
            set { SetValue(ref this.isEnable, value); }
        }
        #endregion

        #region Attributes
        private string password;
        private bool isRunning;
        private bool isEnable;
        #endregion

        #region Commands
        public ICommand LoginCommand 
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        public ICommand RegisterCommand { get;}
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnable = true;
        }

        #endregion

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You mus enter an email",
                    "Accept"
                    );
                this.IsRunning = true;
                this.IsEnable = false;
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password",
                    "Accept"
                    );
                this.IsRunning = true;
                this.IsEnable = false;
                return;
            }

            this.IsRunning = false;
            this.IsEnable = true;

        }
    }
}
