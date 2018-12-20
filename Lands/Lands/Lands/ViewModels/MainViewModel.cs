namespace Lands.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels

        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }

        #endregion ViewModels

        #region Constructors

        public MainViewModel()
        {
            /// TODO 022 al crear la clase se inicializa la instancia
            instance = this;
            this.Login = new LoginViewModel();
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
    }
}