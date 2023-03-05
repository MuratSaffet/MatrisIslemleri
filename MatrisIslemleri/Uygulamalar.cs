using MatrisIslemleri.Extensions;

namespace MatrisIslemleri
{
    internal class Uygulamalar
    {
        private static readonly MenuIslemleri _menuIslemleri = MenuIslemleri.NesneOlusturma();
        private int[,] matris = null;
        private short satir = default, sutun = default;
        public Uygulamalar()
        {

        }

        public bool UygulamaCalistirma(string uygulamaNumarasi = "")
        {
            int[,] matris = null;
            bool durum = true;
            Console.Clear();
            if (int.TryParse(uygulamaNumarasi, out int numara))
            {
                if (numara == 1)
                {
                    SifirMatrisMi();
                }
                else if (numara == 2)
                {
                    KareMatrisOlusturma();
                }
                else if (numara == 3)
                {
                    BirimMatrisMi();
                }
                else if (numara == 4)
                {
                    IkiMatrisEsitMi();
                }
                else if (numara == 5)
                {
                    DevrikBulma();
                }
                else if (numara == 6)
                {
                    MatrisIleTamSayiCarpma();
                }
                else if (numara == 7)
                {
                    IkiMatrisToplama();
                }
                else if (numara == 8)
                {
                    IkiMatrisCikarma();
                }
                else if (numara == 9)
                {
                    IkiMatrisCarpma();
                }
                else if (numara == 10)
                {
                    KareMatrisKuvvetAl();
                }
                else
                {
                    Console.WriteLine(Mesajlar.Sonlandirma);
                    return false;
                }
            }
            else
            {
                Console.WriteLine(Mesajlar.Sonlandirma);
                return false;
            }

            Console.Write(Mesajlar.DevamSorusu);
            string cevap = Console.ReadLine();
            if (!(cevap.Equals("e") || cevap.Equals("E")))
                durum = false;
            return durum;
        }

        private void KareMatrisKuvvetAl()
        {
            int[,] sonucMatris = null;
            int[,] araIslemMatris = null;
            int kuvvet = default;
            try
            {
                Console.Write(Mesajlar.Satir);
                satir = Convert.ToInt16(Console.ReadLine());

                Console.Write(Mesajlar.Sutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                if (satir != sutun)
                {
                    Console.WriteLine(Mesajlar.KareMatrisUyarisi);
                    return;
                }

                matris = new int[satir, sutun]; //girilen boyuta uygun matris olusturulmasi
                sonucMatris = new int[satir, sutun];
                araIslemMatris = new int[satir, sutun];

                MatrisElemanlariniAlma(ref matris, Mesajlar.MatrisElemanlariG);

                Console.Write("\nKuvveti(pozitif bir tam sayı olsun) girin: ");
                kuvvet = Convert.ToInt32(Console.ReadLine());

                Array.Copy(matris, sonucMatris, matris.Length);
                Array.Copy(matris, araIslemMatris, matris.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HataMesaji());
                return;
            }

            while ((kuvvet - 1) > 0)
            {
                //kuvvet 3 ise 2 kere çarpma yapacak demektir.
                // İki matris çarpılıyor.
                for (int i = 0; i < satir; i++)
                {
                    for (int k = 0; k < sutun; k++)
                    {
                        int geciciToplam = 0;
                        for (int j = 0; j < satir; j++)
                        {
                            geciciToplam += araIslemMatris[i, j] * matris[j, k];
                        }
                        sonucMatris[i, k] = geciciToplam;
                    }
                }

                #region araIslemMatris güncellenmesi
                Array.Copy(sonucMatris, araIslemMatris, sonucMatris.Length);
                #endregion

                kuvvet--;
            }

            MatrisGosterme(matris, Mesajlar.MatrisElemanlari);

            MatrisGosterme(sonucMatris, "Kuvvet alma sonucu oluşan matris aşağıdadır:");
        }

        private void MatrisIleTamSayiCarpma()
        {
            int carpilacakSayi = default;
            try
            {
                Console.Write(Mesajlar.Satir);
                satir = Convert.ToInt16(Console.ReadLine());

                Console.Write(Mesajlar.Sutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                matris = new int[satir, sutun];

                MatrisElemanlariniAlma(ref matris, Mesajlar.MatrisElemanlariG);

                Console.Write("Matrisin çarpılacağı tam sayıyı girin: ");
                carpilacakSayi = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HataMesaji());
                return;
            }

            MatrisGosterme(matris, Mesajlar.MatrisElemanlari);

            // çarpım yapılıyor
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    matris[i, j] *= carpilacakSayi;
                }
            }

            MatrisGosterme(matris, "Çarpım sonucu oluşan matris  aşağıdadır:");
        }

        private void DevrikBulma()
        {
            try
            {
                Console.Write(Mesajlar.Satir);
                satir = Convert.ToInt16(Console.ReadLine());

                Console.Write(Mesajlar.Sutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                matris = new int[satir, sutun];  //girilen boyuta uygun matris oluşturulması. 

                MatrisElemanlariniAlma(ref matris, Mesajlar.MatrisElemanlariG);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HataMesaji());
                return;
            }

            MatrisGosterme(matris, Mesajlar.MatrisElemanlari);

            int[,] mtranspoz = new int[sutun, satir];
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    mtranspoz[j, i] = matris[i, j];
                }
            }

            MatrisGosterme(mtranspoz, "Matrisin transpozu(devriği) aşağıdadır:");
        }

        private void IkiMatrisEsitMi()
        {
            int[,] matris1 = null;
            int[,] matris2 = null;

            try
            {
                Console.Write(Mesajlar.IlkSatir);
                satir = Convert.ToInt16(Console.ReadLine());
                Console.Write(Mesajlar.IlkSutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                matris1 = new int[satir, sutun]; //girilen boyuta uygun ilk matris oluşturulmasi 

                Console.Write(Mesajlar.IkinciSatir);
                satir = Convert.ToInt16(Console.ReadLine());
                Console.Write(Mesajlar.IkinciSutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                if (matris1.GetLength(0) != satir || matris1.GetLength(1) != sutun)
                {
                    Console.WriteLine(Mesajlar.EsitBoyutKuraliUyarisi);
                    Console.WriteLine(Mesajlar.KuralaUymama);
                    return;
                }

                matris2 = new int[satir, sutun]; //girilen boyuta uygun ilk matris oluşturulmasi 

                MatrisElemanlariniAlma(ref matris1, Mesajlar.BirinciMatrisElemanlariG);
                MatrisElemanlariniAlma(ref matris2, Mesajlar.IkinciMatrisElemanlariG);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HataMesaji());
                return;
            }

            MatrisGosterme(matris1, Mesajlar.BirinciMatrisElemanlari);
            MatrisGosterme(matris2, Mesajlar.IkinciMatrisElemanlari);

            // İki matris eşit mi diye kontrol ediyor
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    if (matris1[i, j] != matris2[i, j]) 
                    { 
                        Console.WriteLine("İki matris eşit değil");
                        return;
                    }
                }
            }
            Console.WriteLine("İki matris eşit");
        }

        private void BirimMatrisMi()
        {
            try
            {
                Console.Write(Mesajlar.Satir);
                satir = Convert.ToInt16(Console.ReadLine());

                Console.Write(Mesajlar.Sutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                if (satir != sutun)
                {
                    Console.WriteLine("Birim Matris değil. Çünkü boyutlar eşit değil.");
                    return;
                }
                matris = new int[satir, sutun];  //girilen boyuta uygun matris oluşturulması. 

                MatrisElemanlariniAlma(ref matris, Mesajlar.MatrisElemanlariG);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HataMesaji());
                return;
            }

            MatrisGosterme(matris, Mesajlar.MatrisElemanlari);

            // birim matrisi mi diye kontrol ediyor
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    if ((i == j && matris[i, j] != 1) || (i != j && matris[i, j] != 0))
                    {
                        Console.WriteLine("Birim Matris değil");
                        return;
                    }
                }
            }

            Console.WriteLine("Birim Matris");
        }

        private void KareMatrisOlusturma()
        {
            try
            {
                Console.Write(Mesajlar.Satir);
                satir = Convert.ToInt16(Console.ReadLine());

                Console.Write(Mesajlar.Sutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                if (satir != sutun)
                {
                    Console.WriteLine(Mesajlar.KareMatrisUyarisi);
                    return;
                }
                matris = new int[satir, sutun];  //girilen boyuta uygun matris oluşturulması. 

                MatrisElemanlariniAlma(ref matris, Mesajlar.MatrisElemanlariG);

                MatrisGosterme(matris, Mesajlar.MatrisElemanlari);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HataMesaji());
                return;
            }
        }

        private void SifirMatrisMi()
        {
            try
            {
                Console.Write(Mesajlar.Satir);
                satir = Convert.ToInt16(Console.ReadLine());

                Console.Write(Mesajlar.Sutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                matris = new int[satir, sutun]; //girilen boyuta uygun matris oluşturulmasi 

                MatrisElemanlariniAlma(ref matris, Mesajlar.MatrisElemanlariG);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HataMesaji());
                return;
            }

            MatrisGosterme(matris, Mesajlar.MatrisElemanlari);

            // sifir matrisi mi diye kontrol ediyor
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    if (matris[i, j] != 0)
                    {
                        Console.WriteLine("Sıfır Matris değil");
                        return;
                    }
                }
            }

            Console.WriteLine("Sıfır Matris");
        }

        private void IkiMatrisCikarma()
        {
            int[,] matris1 = null;
            int[,] matris2 = null;

            try
            {
                Console.Write(Mesajlar.IlkSatir);
                satir = Convert.ToInt16(Console.ReadLine());
                Console.Write(Mesajlar.IlkSutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                matris1 = new int[satir, sutun];

                Console.Write(Mesajlar.IkinciSatir);
                satir = Convert.ToInt16(Console.ReadLine());
                Console.Write(Mesajlar.IkinciSutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                matris2 = new int[satir, sutun];

                if (matris1.GetLength(0) != matris2.GetLength(0) || matris1.GetLength(1) != matris2.GetLength(1))
                {
                    Console.WriteLine(Mesajlar.EsitBoyutKuraliUyarisi);
                    Console.WriteLine(Mesajlar.KuralaUymama);
                    return;
                }

                MatrisElemanlariniAlma(ref matris1, Mesajlar.BirinciMatrisElemanlariG);
                MatrisElemanlariniAlma(ref matris2, Mesajlar.IkinciMatrisElemanlariG);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HataMesaji());
                return;
            }

            #region Iki matrisin cikarma islemi
            int[,] farkMatris = new int[matris1.GetLength(0), matris1.GetLength(1)];
            for (int i = 0; i < matris1.GetLength(0); i++)
            {
                for (int j = 0; j < matris1.GetLength(1); j++)
                {
                    farkMatris[i, j] = matris1[i, j] - matris2[i, j];
                }
            }
            #endregion

            MatrisGosterme(matris1, Mesajlar.BirinciMatrisElemanlari);
            MatrisGosterme(matris2, Mesajlar.IkinciMatrisElemanlari);
            MatrisGosterme(farkMatris, Mesajlar.CikarmaSonucu);
        }

        private void IkiMatrisToplama()
        {
            int[,] matris1 = null;
            int[,] matris2 = null;

            try
            {
                Console.Write(Mesajlar.IlkSatir);
                satir = Convert.ToInt16(Console.ReadLine());
                Console.Write(Mesajlar.IlkSutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                matris1 = new int[satir, sutun];

                Console.Write(Mesajlar.IkinciSatir);
                satir = Convert.ToInt16(Console.ReadLine());
                Console.Write(Mesajlar.IkinciSutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                matris2 = new int[satir, sutun];

                if (matris1.GetLength(0) != matris2.GetLength(0) || matris1.GetLength(1) != matris2.GetLength(1))
                {
                    Console.WriteLine(Mesajlar.EsitBoyutKuraliUyarisi);
                    Console.WriteLine(Mesajlar.KuralaUymama);
                    return;
                }

                MatrisElemanlariniAlma(ref matris1, Mesajlar.BirinciMatrisElemanlariG);
                MatrisElemanlariniAlma(ref matris2, Mesajlar.IkinciMatrisElemanlariG);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HataMesaji());
                return;
            }

            #region Iki matrisin toplama islemi
            int[,] toplamMatris = new int[matris1.GetLength(0), matris1.GetLength(1)];
            for (int i = 0; i < matris1.GetLength(0); i++)
            {
                for (int j = 0; j < matris1.GetLength(1); j++)
                {
                    toplamMatris[i, j] = matris1[i, j] + matris2[i, j];
                }
            }
            #endregion

            MatrisGosterme(matris1, Mesajlar.BirinciMatrisElemanlari);
            MatrisGosterme(matris2, Mesajlar.IkinciMatrisElemanlari);
            MatrisGosterme(toplamMatris, Mesajlar.ToplamaSonucu);
        }

        /// <summary>
        /// Iki boyutlu matrisin carpimi 
        /// </summary>
        private void IkiMatrisCarpma()
        {
            int[,] matris1 = null;
            int[,] matris2 = null;

            try
            {
                Console.Write(Mesajlar.IlkSatir);
                satir = Convert.ToInt16(Console.ReadLine());
                Console.Write(Mesajlar.IlkSutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                matris1 = new int[satir, sutun];


                Console.Write(Mesajlar.IkinciSatir);
                satir = Convert.ToInt16(Console.ReadLine());

                if (sutun != satir)
                {
                    Console.WriteLine(Mesajlar.CarpmaKuraliUyarisi);
                    Console.WriteLine(Mesajlar.KuralaUymama);
                    return;
                }

                Console.Write(Mesajlar.IkinciSutun);
                sutun = Convert.ToInt16(Console.ReadLine());

                matris2 = new int[satir, sutun];

                MatrisElemanlariniAlma(ref matris1, Mesajlar.BirinciMatrisElemanlariG);
                MatrisElemanlariniAlma(ref matris2, Mesajlar.IkinciMatrisElemanlariG);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.HataMesaji());
                return;
            }

            #region iki matrisin carpimi
            int[,] carpim = new int[matris1.GetLength(0), matris2.GetLength(1)];

            for (int s = 0; s < matris1.GetLength(0); s++)
            {
                for (int m = 0; m < matris2.GetLength(1); m++)
                {
                    int toplam = default;
                    for (int a = 0; a < matris2.GetLength(0); a++)
                    {
                        toplam += matris1[s, a] * matris2[a, m];
                    }
                    carpim[s, m] = toplam;
                }
            }
            #endregion

            MatrisGosterme(matris1, Mesajlar.BirinciMatrisElemanlari);
            MatrisGosterme(matris2, Mesajlar.IkinciMatrisElemanlari);
            MatrisGosterme(carpim, Mesajlar.CarpmaSonucu);
        }

        /// <summary>
        /// İki boyutlu bir matris icin bilgilerin ekranda alinmasi
        /// </summary>
        /// <param name="matris"></param>
        /// <param name="mesaj">Bilgi alinmasindan once ekranda gosterilecek aciklama yazisi</param>
        private void MatrisElemanlariniAlma(ref int[,] matris, string mesaj)
        {
            Console.WriteLine(mesaj);
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    Console.Write($"{i}. satır ve {j}. sütundaki sayıyı giriniz: ");
                    matris[i, j] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// İki boyutlu bir matrisin ekranda gosterilmesi
        /// </summary>
        /// <param name="matris">Matris</param>
        /// <param name="mesaj">Matristen once ekranda gosterilecek aciklama yazisi</param>
        private void MatrisGosterme(int[,] matris, string mesaj)
        {
            Console.WriteLine(mesaj);
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    Console.Write(matris[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
}
