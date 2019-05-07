namespace Lands.ViewModels
{
    using Lands.Helpers;
    using Lands.Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MainViewModel
    {
        #region Properties

        public List<Land> LandsList { get; set; }

        //To get token
        public string Token { get; set; }
        public string TokenType { get; set; }

        public ObservableCollection<MenuItemViewModel> Menus{ get; set; }

        #endregion Properties

        #region ViewModels

        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }
        public RegisterViewModel Register { get; set; }

        #endregion ViewModels

        #region Constructors

        public MainViewModel()
        {
            /// TODO 022 al crear la clase se inicializa la instancia
            instance = this;
            this.Login = new LoginViewModel();
            this.Menus = new ObservableCollection<MenuItemViewModel>();
            this.LoadMenu();
        }

        #endregion Constructors

        #region Singleton

        /// <summary>
        /// TODO 020 Para el singleton se crea una instancia estática
        /// del objeto o clase que queremos referenciar.
        /// </summary>
        private static MainViewModel instance;

        /// <summary>
        /// TODO 021 Se crea el método que obtendrá la viewmodel.
        /// </summary>
        /// <returns></returns>
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }

        #endregion Singleton

        #region Methods
        private void LoadMenu()
        {
            this.Menus.Add(
                new MenuItemViewModel
                {
                    Icon = "ic_settings",
                    PageName = "MyProfilePage",
                    Title = Languages.MyProfile
                }
                );

            this.Menus.Add(
                new MenuItemViewModel
                {
                    Icon = "ic_insert_chart",
                    PageName = "StatisticsPage",
                    Title = Languages.Statistic
                }
                );

            this.Menus.Add(
                new MenuItemViewModel
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = Languages.LogOut
                }
                );
        }
        #endregion
    }
}