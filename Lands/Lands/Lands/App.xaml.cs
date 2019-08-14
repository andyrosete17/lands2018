namespace Lands
{
    using Helpers;
    using Lands.Models;
    using Lands.ViewModels;
    using Lands.Views;
    using Xamarin.Forms;

    public partial class App : Application
    {
        #region Properties
        public static NavigationPage Navigator
        {
            get;
            internal set;
        }
        #endregion

        #region Variables
        public static string root_db;
        #endregion

        #region Constructors

        public App()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Settings.Token))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                //Cuando hace el login se esta pasadon el tokemn que esta almacenado en memoria, también hay que recuperar el usuario de la base de datos de
                //SQLite
                //var dataService = new DataService();
                //var user = dataService.First<UserLocal>(false);
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.Lands = new LandsViewModel();
                //mainViewModel.User = user;
                MainPage = new MasterPage();
            }
        }
        public App(string root_DB)
        {
            InitializeComponent();

            //Set root SQLite
            root_db = root_DB;

            //this.MainPage =new NavigationPage (new LoginPage());

            if (string.IsNullOrEmpty(Settings.Token))
            {
                this.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                //Connection with SQLite
                var user = new UserLocal();

                using (var conn = new SQLite.SQLiteConnection(App.root_db))
                {
                    conn.CreateTable<UserLocal>();
                    user = conn.Table<UserLocal>().FirstOrDefault();
                }

                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.User = user;//sqlite
                this.MainPage = new MasterPage();
            }
        }

        #endregion Constructors

            #region Methods

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion Methods
    }
}