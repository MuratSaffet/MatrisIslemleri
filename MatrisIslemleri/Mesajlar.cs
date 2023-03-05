namespace MatrisIslemleri
{
    internal static class Mesajlar
    {
        public const string Sonlandirma = "Uygun bir değer girmediğinizden uygulama sonlandırıldı...";
        public const string DevamSorusu = "\nDevam etmek istiyorsanız e/E tuşlarından birine basınız: ";
        public const string KuralaUymama = "Girdiğiniz veriler bu kurala uymadığından işlem yapılamıyor.";
        public const string EsitBoyutKuraliUyarisi = "Matrislerin boyutları eşit olmadığından işlem yapılamaz.";
        
        public const string ToplamaSonucu = "Toplam sonucu oluşan matris aşağıdadır:";
        public const string CikarmaSonucu = "Çıkarma sonucu oluşan matris aşağıdadır:";
        public const string CarpmaKuraliUyarisi = "İki matrisi çarpabilmek için ilk matrisin sütun sayısının ikinci matrisin satır sayısına eşit olması gerekir.";
        public const string CarpmaSonucu = "İki matrisin çarpım sonucu:";
        public const string KareMatrisUyarisi = "Girilen boyutlar kare matris için uygun değil.\nBoyutlar kare matris için  eşit olmalı!";

        public const string MatrisElemanlariG = "Matrisin elemanlarını giriniz";
        public const string MatrisElemanlari = "Matrisin elemanları:";

        public const string BirinciMatrisElemanlariG = "Birinci matrisin elemanlarını giriniz";
        public const string IkinciMatrisElemanlariG = "İkinci matrisin elemanlarını giriniz";

        public const string BirinciMatrisElemanlari = "Birinci matrisin elemanları:";
        public const string IkinciMatrisElemanlari = "İkinci matrisin elemanları:";

        public const string Satir = "Matrisin SATIR sayısını giriniz: ";
        public const string Sutun = "Matrisin SÜTUN sayısını giriniz: ";

        public const string IlkSatir = "İlk matrisin SATIR sayısını giriniz: ";
        public const string IlkSutun = "İlk matrisin SÜTUN sayısını giriniz: ";

        public const string IkinciSatir = "İkinci matrisin SATIR sayısını giriniz: ";
        public const string IkinciSutun = "İkinci matrisin SÜTUN sayısını giriniz: ";

        #region Hata turu mesajlari
        public const string SystemFormatException = "Girilen değer bir sayıya dönüştürülemiyor! Bu yüzden işlem yapılamıyor.";
        public const string SystemOverflowException = "Girilen değer kabul edilen değer aralığının dışında! Bu yüzden işlem yapılamıyor.";
        #endregion
    }
}
