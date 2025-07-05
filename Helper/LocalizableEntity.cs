using System.Globalization;

namespace MCV_Empity.Helper
{
    public class LocalizableEntity
    {
        public string Localize(string nameAr ,string nameEn)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower() == "ar")
                return nameAr;
            
        
                return nameEn;
            
        }
    }
}
