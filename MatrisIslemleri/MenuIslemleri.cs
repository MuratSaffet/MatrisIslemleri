namespace MatrisIslemleri
{
    internal class MenuIslemleri
    {
        private static Dictionary<short, string> menu = new();
        private static MenuIslemleri _menuIslemleri;
        private static object _locked = new object();
        private MenuIslemleri()
        {

        }

        public static MenuIslemleri NesneOlusturma()
        {
            lock (_locked)
            {
                if (_menuIslemleri == null)
                {
                    _menuIslemleri = new MenuIslemleri();
                    MenuDoldurma();
                }
            }
            return _menuIslemleri;
        }

        private static void MenuDoldurma()
        {
            menu.Add(1, "Girilen matris, sifir matris mi diye kontrol etme");
            menu.Add(2, "Kullanıcının kare matris oluşturmasını sağlama");
            menu.Add(3, "Girilen matris birim matris mi diye kontrol etme");
            menu.Add(4, "Girilen iki matrisin eşit olup olmadığını bulma");
            menu.Add(5, "Girilen matrisin transpozunu(devriğini) bulma");
            menu.Add(6, "Girilen matrisi bir tam sayı ile çarpma");
            menu.Add(7, "Girilen iki matrisi toplama");
            menu.Add(8, "Girilen iki matris için çıkarma işlemi yapma");
            menu.Add(9, "Girilen iki matrisi çarpma");
            menu.Add(10, "Kare matrisin kuvvetini alma");

            menu.Add(0, "Yapmak istediğiniz işlemin numarasını giriniz\nGeçersiz bir değer girildiğinde uygulamadan çıkılacaktır: ");

            menu = menu.OrderBy(s => s.Key).ToDictionary(m => m.Key, m => m.Value);//Siralaniyor
        }

        public string MenuGosterme()
        {
            Console.Clear();//Konsol temizleniyor

            foreach (var keyValue in menu.Skip(1))
            {
                Console.WriteLine($"{keyValue.Key}- {keyValue.Value}");
            }
            Console.WriteLine("");
            Console.Write($"{menu[menu.Keys.First()]}");

            return Console.ReadLine();
        }
    }
}
