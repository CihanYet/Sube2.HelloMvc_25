namespace DI_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Islemler isl = new Islemler(new Ogrenci());
            isl.KayitYap(); 
        }
    }

    class Personel : IKayit
    {
        public void Kaydet()
        {
            Console.WriteLine("Personel Kaydedildi...");
        }
    }

    class Ogrenci : IKayit
    {
        public void Kaydet()
        {
            Console.WriteLine("Öğrenci Kaydedildi..");
        }
    }

    class Islemler
    {
        IKayit _kayit;

        public Islemler(IKayit kayit)
        {
            _kayit = kayit;
        }

        public void KayitYap()
        {
            _kayit.Kaydet();
        }
    }

    interface IKayit
    {
        void Kaydet();
    }

}