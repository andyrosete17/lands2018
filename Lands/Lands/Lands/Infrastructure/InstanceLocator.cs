namespace Lands.Infrastructure
{
    using ViewModels;

    public class InstanceLocator
    {
        #region Properties
        public MainViewModel Main { get; set; }
        #endregion

        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
        /// TODO 013 Main entonces es una instancia de la main viewmodel
        /// de esta forma se liga la mainviewmodel con la main
    }
}
