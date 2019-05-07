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

        public static string MyProfile
        {
            get { return Resource.MyProfile; }
        }

        public static string Statistic
        {
            get { return Resource.Statistic; }
        }

        public static string LogOut
        {
            get { return Resource.LogOut; }
        }

        public static string Borders
        {
            get { return Resource.Borders; }
        }

        public static string Currency
        {
            get { return Resource.Currency; }
        }

        public static string General
        {
            get { return Resource.General; }
        }

        public static string Lands
        {
            get { return Resource.Lands; }
        }

        public static string Land
        {
            get { return Resource.Land; }
        }
        public static string Language
        {
            get { return Resource.Language; }
        }

        public static string Translation
        {
            get { return Resource.Translation; }
        }

        public static string RegisterTitle
        {
            get { return Resource.RegisterTitle; }
        }

        public static string ChangeImage
        {
            get { return Resource.ChangeImage; }
        }

        public static string FirstNameLabel
        {
            get { return Resource.FirstNameLabel; }
        }

        public static string FirstNamePlaceHolder
        {
            get { return Resource.FirstNamePlaceHolder; }
        }

        public static string FirstNameValidation
        {
            get { return Resource.FirstNameValidation; }
        }

        public static string LastNameLabel
        {
            get { return Resource.LastNameLabel; }
        }

        public static string LastNamePlaceHolder
        {
            get { return Resource.LastNamePlaceHolder; }
        }

        public static string LastNameValidation
        {
            get { return Resource.LastNameValidation; }
        }

        public static string PhoneLabel
        {
            get { return Resource.PhoneLabel; }
        }

        public static string PhonePlaceHolder
        {
            get { return Resource.PhonePlaceHolder; }
        }

        public static string PhoneValidation
        {
            get { return Resource.PhoneValidation; }
        }

        public static string ConfirmLabel
        {
            get { return Resource.ConfirmLabel; }
        }

        public static string ConfirmPlaceHolder
        {
            get { return Resource.ConfirmPlaceHolder; }
        }

        public static string ConfirmValidation
        {
            get { return Resource.ConfirmValidation; }
        }

        public static string EmailValidation2
        {
            get { return Resource.EmailValidation2; }
        }

        public static string PasswordValidation2
        {
            get { return Resource.PasswordValidation2; }
        }

        public static string ConfirmValidation2
        {
            get { return Resource.ConfirmValidation2; }
        }

        public static string UserRegisteredMessage
        {
            get { return Resource.UserRegisteredMessage; }
        }

        public static string SourceImageQuestion
        {
            get { return Resource.SourceImageQuestion; }
        }

        public static string Cancel
        {
            get { return Resource.Cancel; }
        }

        public static string FromGallery
        {
            get { return Resource.FromGallery; }
        }

        public static string FromCamera
        {
            get { return Resource.FromCamera; }
        }

        public static string Save
        {
            get { return Resource.Save; }
        }

        public static string ChangePassword
        {
            get { return Resource.ChangePassword; }
        }

        public static string CurrentPassword
        {
            get { return Resource.CurrentPassword; }
        }

        public static string CurrentPasswordPlaceHolder
        {
            get { return Resource.CurrentPasswordPlaceHolder; }
        }

        public static string NewPassword
        {
            get { return Resource.NewPassword; }
        }

        public static string NewPasswordPlaceHolder
        {
            get { return Resource.NewPasswordPlaceHolder; }
        }

        public static string ConnectionError1
        {
            get { return Resource.ConnectionError1; }
        }

        public static string ConnectionError2
        {
            get { return Resource.ConnectionError2; }
        }

        public static string LoginError
        {
            get { return Resource.LoginError; }
        }

        public static string ChagePasswordConfirm
        {
            get { return Resource.ChagePasswordConfirm; }
        }

        public static string PasswordError
        {
            get { return Resource.PasswordError; }
        }

        public static string ErrorChangingPassword
        {
            get { return Resource.ErrorChangingPassword; }
        }

    }
}