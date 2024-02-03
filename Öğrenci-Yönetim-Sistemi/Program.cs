using Öğrenci_Yönetim_Sistemi;

namespace Öğrenci_Yönetim_Uygulaması
{
    internal class Program
    {
        static  List<Ogrenci> ogrenciler = new List<Ogrenci>(); //global değişken tanımlama
        static bool devamMi = true;
        static void Main(string[] args)
        {
            //SahteVeriGir();           
            Giris();
            Uygulama();
            Console.WriteLine("Program şimdi bitti.");

        }
        static void OgrenciSil()
        {
            Console.WriteLine("3 - Öğrenci Sil----------");
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek öğrenci yok.");
                return;
            }
            Console.WriteLine("Silmek istediğiniz öğrencinin");
            Console.Write("No: ");
            int no = Convert.ToInt32(Console.ReadLine());
            Ogrenci o = null;

            foreach (Ogrenci x in ogrenciler)
            {
                if (x.No == no)
                {
                    o = x;
                }
            }
            if (o != null)
            {
                  Console.WriteLine("Adı: " + o.Ad);
                  Console.WriteLine("Soyadı: " + o.Soyad);
                  Console.WriteLine("Şubesi: " + o.Sube);
                  Console.WriteLine();
                  Console.Write("Öğrenciyi silmek istediğinize emin misiniz? (E / H) ");
                  string giris = Console.ReadLine().ToLower();
                  Console.WriteLine();
                  if (giris == "e")
                  {
                      ogrenciler.Remove(o);
                      Console.WriteLine("Öğrenci silindi.");
                  }
                  else 
                  {
                      Console.WriteLine("Öğrenci silinemedi.");
                  
                  }               
            }
            else
            {
                Console.WriteLine("Böyle bir öğrenci bulunamadı.");
            }
                
            
            
            

        }
        static void OgrenciEkle()
        {
            Ogrenci ogr = new Ogrenci();

            Console.WriteLine("1- Örenci Ekle -----------");
            int kacinci = ogrenciler.Count + 1;
            Console.WriteLine(kacinci + ". Öğrencinin ");
            bool sonuc;
            do
            {
                Console.Write("No: ");
                ogr.No = int.Parse(Console.ReadLine());
                sonuc = NoVarMi(ogr.No);
                if (sonuc)
                {
                    Console.WriteLine("Bu numarada bir öğrenci var. Tekrar deneyin.");
                }

            } while (sonuc);

            Console.Write("Adı: ");
            ogr.Ad = IlkHarfiBuyut(Console.ReadLine());

            Console.Write("Soyadı: ");
            ogr.Soyad = IlkHarfiBuyut(Console.ReadLine());

            Console.Write("Şubesi: ");
            ogr.Sube = IlkHarfiBuyut(Console.ReadLine());


            Console.WriteLine();
            Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H) ");
            string giris = Console.ReadLine();
            if (giris.ToUpper() == "E")
            {
                ogrenciler.Add(ogr);
                Console.WriteLine("Öğrenci eklendi.");
            }
            else if (giris == "H")
            {
                Console.WriteLine("Öğrenci eklenmedi.");
            }
            
        }
        static bool NoVarMi(int no)
        {
            foreach (Ogrenci item in ogrenciler)
            {
                if (item.No == no)
                {
                    return true;
                }
            }
            return false;
        }
        static void OgrenciListele()
        {
            Console.WriteLine("2 - Öğrenci Listele---------- -   ");
            Console.WriteLine();
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede gösterilecek öğrenci yok.");
                return;
            }
            Console.WriteLine("Şube".PadRight(8) + "No".PadRight(8) + "Ad Soyad");
            Console.WriteLine("".PadLeft(30, '-'));
            foreach (Ogrenci item in ogrenciler)
            {
                Console.WriteLine(item.Sube.PadRight(8) + item.No.ToString().PadRight(8) + item.Ad + " " + item.Soyad);
            }



        }
        static void Uygulama()
        {
            while (devamMi)
            {
                string secim = Seciminiz();
                Console.WriteLine();
                switch (secim)
                {
                    case "1":
                    case "e":
                        OgrenciEkle();
                        break;
                    case "2":
                    case "l":
                        OgrenciListele();
                        break;
                    case "3":
                    case "s":
                        OgrenciSil();
                        break;
                    case "4":
                    case "x":
                        Cikis();
                        break;
                }

            }
        }
        static void Giris()
        {
            Console.WriteLine("Örenci Yönetim Uygulaması");
            Console.WriteLine("1- Örenci Ekle (E)");
            Console.WriteLine("2- Örenci Listele (L)");
            Console.WriteLine("3- Öğrenci Sil (S)");
            Console.WriteLine("4- Çıkış (X)");
            Console.WriteLine();
        }
        static void SahteVeriGir()
        {
            Ogrenci ogrenci1 = new Ogrenci();
            ogrenci1.Ad = "Harun";
            ogrenci1.Soyad = "Kazdal";
            ogrenci1.No = 12;
            ogrenci1.Sube = "A";

            //Ogrenci ogrenci2 = new Ogrenci();
            //ogrenci2.Adi = "Ahmet";
            //ogrenci2.Soyadi = "Doğan";
            //ogrenci2.No = 60;
            //ogrenci2.Subesi = "B";

            //Ogrenci ogrenci3 = new Ogrenci();
            //ogrenci3.Adi = "Ayşe";
            //ogrenci3.Soyadi = "Yılmaz";
            //ogrenci3.No = 32;
            //ogrenci3.Subesi = "C";

            ogrenciler.Add(ogrenci1);
            //ogrenciler.Add(ogrenci2);
            //ogrenciler.Add(ogrenci3);

            foreach (Ogrenci o in ogrenciler)
            {
                Console.WriteLine(o.No + "   " + o.Ad + "   " + o.Soyad + "   " + o.Sube);
            }
        }
        static string Seciminiz()
        {
            int sayac = 0;
            string karakterler = "1234ESLX";
            while (true)
            {
                sayac++;
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                string giris = Console.ReadLine().ToUpper();
                if (karakterler.IndexOf(giris) > -1 && giris.Length == 1)
                {
                    return giris;
                }
                else if (sayac == 5)
                {
                    Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                    Cikis();
                }
                Console.WriteLine("Hatalı giriş yapıldı.");
            }
        }
        static void Cikis()
        {
            Environment.Exit(0);
        }
        static string IlkHarfiBuyut(string veri)
        {
            return veri[0].ToString().ToUpper() + veri.Substring(1).ToLower();
        }
    }
}
