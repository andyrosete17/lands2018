namespace Lands.Helpers
{
    using Lands.Interfaces;
    using Lands.Resources;
    using Xamarin.Forms;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }

        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string PasswordValidation
        {
            get { return Resource.PasswordValidation; }
        }

        public static string GenericErrorValidation
        {
            get { return Resource.GenericErrorValidation; }
        }

        public static string CountryBorderError
        {
            get { return Resource.CountryBorderError; }
        }

        public static string BorderNotFoundError
        {
            get { return Resource.BorderNotFoundError; }
        }

        public static string RememberMe
        {
            get { return Resource.RememberMe; }
        }

        public static string EmailPlaceholder
        {
            get { return Resource.EmailPlaceholder; }
        }

        public static string PasswordPlaceholder
        {
            get { return Resource.PasswordPlaceholder; }
        }

        public static string Password
        {
            get { return Resource.Password; }
        }

        public static string Email
        {
            get { return Resource.Email; }
        }

        public static string ForgotPassword
        {
            get { return Resource.ForgotPassword; }
        }

        public static string Login
        {
            get { return Resource.Login; }
        }

        public static string Register
        {
            get { return Resource.Register; }
        }

        public static string GermanLanguage
        {
            get { return Resource.GermanLanguage; }
        }

        public static string SpanishLanguage
        {
            get { return Resource.SpanishLanguage; }
        }

        public static string FrenchLanguage
        {
            get { return Resource.FrenchLanguage; }
        }

        public static string JapaneseLanguage
        {
            get { return Resource.JapaneseLanguage; }
        }

        public static string ItalianLanguage
        {
            get { return Resource.ItalianLanguage; }
        }

        public static string BrazilianLanguage
        {
            get { return Resource.BrazilianLanguage; }
        }

        public static string PortugueseLanguage
        {
            get { return Resource.PortugueseLanguage; }
        }

        public static string DutchLanguage
        {
            get { return Resource.DutchLanguage; }
        }

        public static string CroatianLanguage
        {
            get { return Resource.CroatianLanguage; }
        }

        public static string PersianLanguage
        {
            get { return Resource.PersianLanguage; }
        }

        public static string Menu
        {
            get { return Resource.Menu; }
        }
    }
}