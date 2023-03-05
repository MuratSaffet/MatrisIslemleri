using System;

namespace MatrisIslemleri.Extensions
{
    static internal class ExceptionExtensions
    {
        /// <summary>
        /// Hatanin turunu bulup o ture gore hata mesajı vermekte.
        /// </summary>
        /// <param name="e">Exception</param>
        /// <returns></returns>
        public static string HataMesaji(this Exception ex)
        {
            string mesaj = string.Empty;
            if (ex.GetType().ToString().Equals(Enums.HataTurleri.SystemFormatException.DescriptionDegeriniBulma()))
                mesaj = Mesajlar.SystemFormatException;
            else if (ex.GetType().ToString().Equals(Enums.HataTurleri.SystemOverflowException.DescriptionDegeriniBulma()))
                mesaj = Mesajlar.SystemOverflowException;

            return mesaj;
        }
    }
}
