using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Araba> arabalar = new List<Araba>(); // Arabaları tutacak liste
        bool devamEt = true;

        while (devamEt)
        {
            Console.WriteLine("Araba üretmek istiyor musunuz? (E/H): ");
            string cevap = Console.ReadLine().ToLower(); // Büyük/küçük harf duyarsız

            if (cevap == "e")
            {
                Araba yeniAraba = ArabaBilgileriniAl(); // Yeni araba oluştur
                arabalar.Add(yeniAraba); // Listeye ekle
            }
            else if (cevap == "h")
            {
                Console.WriteLine("Üretim sona erdi. Üretilen arabalar:");
                foreach (Araba araba in arabalar)
                {
                    Console.WriteLine($"Seri No: {araba.SeriNumarasi}, Marka: {araba.Marka}");
                }
                devamEt = false; // Programı sonlandır
            }
            else
            {
                Console.WriteLine("Geçersiz cevap! Lütfen tekrar deneyin.");
            }
        }
    }

    static Araba ArabaBilgileriniAl()
    {
        Console.Write("Seri Numarası: ");
        string seriNo = Console.ReadLine();

        Console.Write("Marka: ");
        string marka = Console.ReadLine();

        Console.Write("Model: ");
        string model = Console.ReadLine();

        Console.Write("Renk: ");
        string renk = Console.ReadLine();

        int kapiSayisi = KapiSayisiAl(); // Kapı sayısı için geçerli bir sayı al

        return new Araba(seriNo, marka, model, renk, kapiSayisi);
    }

    static int KapiSayisiAl()
    {
    tekrar:
        Console.Write("Kapı Sayısı: ");
        try
        {
            return int.Parse(Console.ReadLine()); // Sayısal olmayan değer girilirse catch'e düşer
        }
        catch (Exception)
        {
            Console.WriteLine("Hatalı giriş! Lütfen sayısal bir değer girin.");
            goto tekrar; // Geçerli bir giriş alınana kadar aynı satıra yönlendir
        }
    }
}

class Araba
{
    public string UretimTarihi { get; } = DateTime.Now.ToString("dd-MM-yyyy");
    public string SeriNumarasi { get; set; }
    public string Marka { get; set; }
    public string Model { get; set; }
    public string Renk { get; set; }
    public int KapiSayisi { get; set; }

    public Araba(string seriNo, string marka, string model, string renk, int kapiSayisi)
    {
        SeriNumarasi = seriNo;
        Marka = marka;
        Model = model;
        Renk = renk;
        KapiSayisi = kapiSayisi;
    }
}

