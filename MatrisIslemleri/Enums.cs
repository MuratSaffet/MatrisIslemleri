using System.ComponentModel;

namespace MatrisIslemleri
{
    internal static class Enums
    {
        public enum HataTurleri
        {
            [Description("System.FormatException")]
            SystemFormatException,
            [Description("System.OverflowException")]
            SystemOverflowException
        }
    }
}
