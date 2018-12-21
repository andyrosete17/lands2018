namespace Lands.ViewModels
{
    using Lands.Models;

    public class LandViewModel
    {
        #region Properties

        public Land Land
        {
            get;
            set;
        }

        #endregion Properties

        #region Constructor

        public LandViewModel(Land land)
        {
            this.Land = land;
        }

        #endregion Constructor
    }
}