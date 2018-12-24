namespace Lands.ViewModels
{
    using Lands.Models;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel : BaseViewModel
    {
        #region Attributes

        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;

        #endregion Attributes

        #region Properties

        public Land Land
        {
            get;
            set;
        }

        public ObservableCollection<Border> Borders
        {
            get => this.borders;
            set => SetValue(ref this.borders, value);
        }

        public ObservableCollection<Currency> Currencies
        {
            get => this.currencies;
            set => SetValue(ref this.currencies, value);
        }

        #endregion Properties

        #region Constructor

        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
        }

        #endregion Constructor

        #region Methods

        private void LoadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance()
                                .LandsList
                                .Where(x => x.Alpha3Code == border)
                                .FirstOrDefault();
                if (land != null)
                {
                    this.Borders.Add(
                    new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name
                    });
                }
            }

            if (!this.Borders.Any())
            {
                this.Borders.Add(new Border { Name = "This Country has no border" });
            }
        }

        #endregion Methods
    }
}