
using MatrisIslemleri;

MenuIslemleri menuIslemleri = MenuIslemleri.NesneOlusturma();
Uygulamalar uygulamalar = new();

bool durum = true;
while (durum)
{
    var numara = menuIslemleri.MenuGosterme();
    durum = uygulamalar.UygulamaCalistirma(numara);
}


