using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace kartOyunu
{
    class Program
    {
        public static int durum = 0;
        static void Main(string[] args)
        {
            // KULLANILAN KARTLARIN KOLAY SİLİNMESİ, KONTROL EDİLMESİ İÇİN LİST KULLANDIM.

            List<string> kartlar = new List<string>();
            kartlar.Add("K1");
            kartlar.Add("K2");
            kartlar.Add("K3");
            kartlar.Add("K4");
            kartlar.Add("K5");
            kartlar.Add("S1");
            kartlar.Add("S2");
            kartlar.Add("S3");
            kartlar.Add("S4");
            kartlar.Add("S5");
            kartlar.Add("M1");
            kartlar.Add("M2");
            kartlar.Add("M3");
            kartlar.Add("M4");
            kartlar.Add("M5");
            kartlar.Add("RD");
            kartlar.Add("RD");
            kartlar.Add("RD");
            List<string> oyuncu1 = new List<string>();
            List<string> oyuncu2 = new List<string>();
            List<string> oyuncu3 = new List<string>();
            List<string> atilanKartlar = new List<string>();
            // kartlar ve oyuncular için liste yapıldı
            Random rastgele = new Random();

            // kartları rasgele 3 oyuncuya dağıttım
            for (int i = 0; i < 6; i++)
            {
                oyuncu1.Add(kartlar[rastgele.Next(0, kartlar.Count)]);
                kartlar.Remove(oyuncu1[i]);
            }
            for (int i = 0; i < 6; i++)
            {
                oyuncu2.Add(kartlar[rastgele.Next(0, kartlar.Count)]);
                kartlar.Remove(oyuncu2[i]);
            }
            for (int i = 0; i < 6; i++)
            {
                oyuncu3.Add(kartlar[rastgele.Next(0, kartlar.Count)]);
                kartlar.Remove(oyuncu3[i]);
            }
            // birinci tur ilk atılan kartın kontrolü ile başlıyor.
            Console.WriteLine("*****Oyun başlasın*****\n |1.tur:|");
            Console.WriteLine("Elindeki kartlar:");
            foreach (string item in oyuncu1)
            {
                Console.Write(item + "  ");
            }

            string ilkAtılanKart = Console.ReadLine();
            ilkAtılanKart.ToUpper();
            ilkAtılanKart = yereAtılanİlkKartınKontrolEdilmesi(ilkAtılanKart, oyuncu1);

            oyuncu1.Remove(ilkAtılanKart);
            Console.WriteLine("Sıra ikinci oyuncuda:");
            ilkAtılanKart = bilgSOyuncu(ilkAtılanKart, oyuncu2, atilanKartlar);

            Console.WriteLine("Sıra üçüncü oyuncuda:");
            ilkAtılanKart = bilgSOyuncu(ilkAtılanKart, oyuncu3, atilanKartlar);
            // birinci tur ilk atılan kartın kontrolü ile başlıyor(yereAtılanİlkKartınKontrolEdilmesi metodu ile). 
            // ve ikinci üçüncü oyuncunun atacağı kart belirlenmesi için bilgSOyuncu metodunu kullandım. 
            int oyunBittiMiKontrol = oyunBittiMi(oyuncu1, oyuncu2, oyuncu3, ilkAtılanKart, atilanKartlar);
            // while de kullanmak için oyunBittiMiKontrol değişkenini kullandım.
            int k = 0;
            while (oyunBittiMiKontrol == 0) // OYUN BİTENE KADAR OYUNUN DEVAM ETMESİ İÇİN WHİLE KULLANDIM
            {

                Console.WriteLine("\n|{0}.tur...|", k + 2);
                Console.WriteLine("Elindeki kartlar:");
                foreach (string item in oyuncu1)
                {
                    Console.Write(item + "  ");
                }

                string[] AtılanKart = new string[10];

                AtılanKart[k] = Console.ReadLine();
                ilkAtılanKart.ToUpper();
                ilkAtılanKart = oyuncu1inKontrolEdilmesi(ilkAtılanKart, AtılanKart[k], oyuncu1, atilanKartlar);

                Console.WriteLine("Sıra 2. oyuncuda:");
                ilkAtılanKart = bilgSOyuncu(ilkAtılanKart, oyuncu2, atilanKartlar);

                Console.WriteLine("Sıra üçüncü oyuncuda:");
                ilkAtılanKart = bilgSOyuncu(ilkAtılanKart, oyuncu3, atilanKartlar);

                oyunBittiMiKontrol = oyunBittiMi(oyuncu1, oyuncu2, oyuncu3, ilkAtılanKart, atilanKartlar);

                // kart bitti mi ya da 3 kere üst üste pas mı geçildi kontrol edilir 

                k++;

            }


            Console.ReadLine();
        }
        public static string oyuncu1inKontrolEdilmesi(string yerdekiKart, string oyuncu1Kart, List<string> oyuncu1, List<string> atilanKartlar)
        {
            //bilgisayar tarafından değil oynayan kişinin attığı kartları kontrol ettim

            string renk = yerdekiKart.Substring(0, 1); // kartın rengini kontrol etmek için substring  kullandım
            string rakam = yerdekiKart.Substring(1, 1); //kartın rakamını kontrol etmek için substring kullandım

        BASADON:
            int sayac = 0;
            for (int i = 0; i < oyuncu1.Count; i++)
            {
                if (oyuncu1Kart == oyuncu1[i] || oyuncu1Kart == "PAS")
                {
                    sayac++;
                    // atılan kartın eldeki kartlardan mı yanlış kart mı olduğunu kontrol etmek için sayac kullanıp 
                    // yanlış ise tekrar seçim yaptırdım
                }

            }
            while (sayac == 0)
            {
                Console.WriteLine("Hatalı seçim. Tekrar seçim yapın:");
                oyuncu1Kart = Console.ReadLine();
                goto BASADON; //yanlış seçimde tekrar başa döndürdüm
            }



            if (oyuncu1Kart.Substring(0, 1) == renk)
            {

                yerdekiKart = oyuncu1Kart;
                Console.WriteLine("yeni kart:" + oyuncu1Kart);
                atilanKartlar.Add(yerdekiKart);// atılan kart atilanKartlar dizisine ekleriz yerdeki kartın değişip değişmediğini,berabere kalma durumunu kontroletmek için kullanırız
                oyuncu1.Remove(yerdekiKart); // kullanılan kartların silinmesi için remove kullandım

            }
            else if (oyuncu1Kart.Substring(oyuncu1Kart.Length - 1, 1) == rakam)
            {

                yerdekiKart = oyuncu1Kart;
                Console.WriteLine("yeni kart:" + oyuncu1Kart);
                atilanKartlar.Add(yerdekiKart);
                oyuncu1.Remove(yerdekiKart);
            }
            else if (oyuncu1Kart == "RD") // renk değiştirme kartının hamlelerini kontrol ettim
            {
                Console.WriteLine("M K S renklerinden birini seçin:");
            SECİM:
                string secim = Console.ReadLine();
                if (secim != "M" && secim != "K" && secim != "S")
                {
                    Console.WriteLine("hatalı secim tekrar secim yapın:");
                    // bu if in içinde yanlış rengin kullanılma durumuna göre tekrar seçim yaptırdım
                    goto SECİM;
                }
                yerdekiKart = secim + yerdekiKart.Substring(1, 1);
                Console.WriteLine("RD kartı kullanıldı.\nYeni kart:{0}" + yerdekiKart.Substring(1, 1), secim);
                atilanKartlar.Add("RD");
                oyuncu1.Remove("RD");
            }
            else if (oyuncu1Kart == "PAS")
            {
                Console.WriteLine("PAS geçildi.\n yerdeki kart:" + yerdekiKart);
                atilanKartlar.Add("PAS");

            }
            else
            {
                Console.WriteLine("Hatalı secim. Tekrar secim yap!");
                oyuncu1Kart = Console.ReadLine();
                yerdekiKart = oyuncu1Kart;

            }

            return yerdekiKart;
        }
        public static string bilgSOyuncu(string ilkAtılanKart, List<string> oyuncu, List<string> atilanKartlar)
        {
            // bilgisayar tarafından yerdeki karta uygun hamle seçilmesini sağladım

            string renk = ilkAtılanKart.Substring(0, 1);
            string rakam = ilkAtılanKart.Substring(1, 1);
            int sayac = 0; // sayac döngüde gereken durum sağlandığı an diğer if'lere girilmemesini sağlamak için kullanıldı

            Random rastgele = new Random();
            for (int i = 0; i < oyuncu.Count; i++)
            {

                if (oyuncu[i].Substring(0, 1) == renk) // eğer yerdeki kart ile eldeki kartın renki uyumlu ise o kart atılır
                {
                    sayac++;
                    if (sayac == 1)
                    {
                        Console.WriteLine("Yeni Kart:" + oyuncu[i]);
                        ilkAtılanKart = oyuncu[i];
                        atilanKartlar.Add(ilkAtılanKart);
                        oyuncu.Remove(ilkAtılanKart);
                        sayac++;
                    }

                }
            }
            if (sayac == 0)
            {
                for (int i = 0; i < oyuncu.Count; i++)
                {

                    if (oyuncu[i].Substring(1, 1) == rakam) // eğer yerdeki kart ile eldeki rakam uyumluysa o kart atılır
                    {
                        sayac++;
                        if (sayac == 1)
                        {
                            Console.WriteLine("Yeni Kart:" + oyuncu[i]);
                            ilkAtılanKart = oyuncu[i];
                            atilanKartlar.Add(ilkAtılanKart);
                            oyuncu.Remove(ilkAtılanKart);
                            sayac++;
                        }
                    }
                }

            }
            if (sayac == 0)
            {
                for (int i = 0; i < oyuncu.Count; i++)
                {
                    if (oyuncu[i] == "RD")
                    {
                        sayac++;

                        if (sayac == 1)
                        {
                            int sayacM = 0;
                            int sayacS = 0;
                            int sayacK = 0;

                            for (int j = 0; j < oyuncu.Count; j++)
                            {
                                if (oyuncu[j].Substring(0, 1) == "M")
                                 sayacM++; 
                                else if (oyuncu[j].Substring(0, 1) == "S")
                                 sayacS++; 
                                else if (oyuncu[j].Substring(0, 1) == "K")
                                 sayacK++; 
                            }
                          
                            // eldeki renk fazlalığına göre fazla olan renk seçilecek
                            if (sayacM > sayacS && sayacM > sayacK || sayacM > sayacS && sayacM == sayacK || sayacM == sayacS && sayacM > sayacK)
                            {
                                if (ilkAtılanKart.Substring(0, 1) != "M")
                                {
                                    ilkAtılanKart = "M" + ilkAtılanKart.Substring(1, 1);
                                    Console.WriteLine("RD kartı kullanıldı.");
                                    Console.WriteLine("Yeni Kart:" + ilkAtılanKart);
                                }
                            }

                            else if (sayacS > sayacM && sayacS > sayacK || sayacS > sayacM && sayacS == sayacK || sayacS > sayacK && sayacS == sayacM)
                            {
                                if (ilkAtılanKart.Substring(0, 1) != "S")
                                {


                                    ilkAtılanKart = "S" + ilkAtılanKart.Substring(1, 1);
                                    Console.WriteLine("RD kartı kullanıldı.");
                                    Console.WriteLine("Yeni Kart:" + ilkAtılanKart);
                                }
                            }
                            else if (sayacK > sayacM && sayacK > sayacS || sayacK > sayacM && sayacK == sayacS || sayacK > sayacS && sayacK == sayacM)
                            {
                                if (ilkAtılanKart.Substring(0, 1) != "K")
                                {


                                    ilkAtılanKart = "K" + ilkAtılanKart.Substring(1, 1);
                                    Console.WriteLine("RD kartı kullanıldı.");
                                    Console.WriteLine("Yeni Kart:" + ilkAtılanKart);
                                }
                            }
                            else if (sayacK == 0 && sayacM == 0 && sayacS == 0)
                            {
                                string[] renkler = new string[] { "M", "K", "S" };
                                string renk1 = renkler[rastgele.Next(1, 3)];
                                ilkAtılanKart = renk1 + ilkAtılanKart.Substring(1, 1);
                                Console.WriteLine("RD kartı kullanıldı.");
                                Console.WriteLine("Yeni Kart:{0}", ilkAtılanKart);
                            }
                            atilanKartlar.Add("RD");
                            oyuncu.Remove("RD");
                            sayac++;
                        }
                    }
                }


            }
            if (sayac == 0)
            {
                for (int i = 0; i < oyuncu.Count; i++)
                {

                    if (oyuncu[i].Substring(0, 1) != renk && oyuncu[i].Substring(1, 1) != rakam || oyuncu[i] != "RD")
                    {
                        sayac++;
                        if (sayac == 1)
                        {
                            Console.WriteLine("Pas geçildi.\nYerdeki Kart:" + ilkAtılanKart);
                            sayac++;
                            atilanKartlar.Add("PAS");
                        }
                    }
                }

            }

            return ilkAtılanKart;
        }

        public static string yereAtılanİlkKartınKontrolEdilmesi(string ilkKart, List<string> oyuncu1)
        {
        // ilk kartın gerekli koşulları sağlamasını kontrol ettim
        BASADON:
            while (ilkKart == "RD" || ilkKart == "PAS")
            {
                Console.WriteLine("Oyun Renk Değiştir(RD) kartı ya da PAS ile başlayamaz! Tekrar seçim yap.");
                ilkKart = Console.ReadLine();
            }

            int sayac = 0;
            for (int i = 0; i < oyuncu1.Count; i++)
            {
                if (ilkKart == oyuncu1[i])
                {
                    sayac++;
                }

            }
            while (sayac == 0)
            {
                Console.WriteLine("Hatalı seçim. Tekrar seçim yapın:");
                ilkKart = Console.ReadLine();
                goto BASADON;
            }
            Console.WriteLine("Yerdeki Kart=" + ilkKart);
            return ilkKart;
        }
        public static int oyunBittiMi(List<string> oyuncu1, List<string> oyuncu2, List<string> oyuncu3, string yerdekiKart, List<string> atilanKartlar)
        {
            //// oyuncunun elinde kart kalmaması durumunda turun sonunda birinci olan açıklanır.
            int sayac1 = 0;
            int sayac = 0;
            if (oyuncu1.Count == 0)
            {
                Console.WriteLine("\n Oyun bitti. Oyunu 1.oyuncu kazandı.");
                sayac1++;
            }
            else if (oyuncu2.Count == 0)
            {
                Console.WriteLine("\n Oyun bitti. Oyunu 2.oyuncu kazandı.");
                sayac1++;
            }
            else if (oyuncu3.Count == 0)
            {
                Console.WriteLine("\n Oyun bitti. Oyunu 3.oyuncu kazandı.");
                sayac1++;
            }
            if (sayac1 != 0)
            {
                sayac++;

                Console.WriteLine("1. oyuncunun kartları:");
                foreach (var item in oyuncu1)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("*****************\n2. oyuncunun kartları:");
                foreach (var item in oyuncu2)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("******************\n3. oyuncunun kartları:");
                foreach (var item in oyuncu3)
                {
                    Console.WriteLine(item);
                }

            }
            // yerdeki kart değişmemesi durumunda oyun berabere biter
            int sayac2 = 0;
            int i = atilanKartlar.Count;
            int j = 3;
            while (atilanKartlar.Count >= j)
            {
                if (atilanKartlar[i - 1] == atilanKartlar[i - 2])
                {
                    if ((atilanKartlar[i - 1] == atilanKartlar[i - 3]))
                    {

                        sayac2++;

                        sayac++;
                    }
                }

                if (atilanKartlar.Count > j++)
                {
                    i--;
                    j++;
                }
            }
            if (sayac2 != 0)
            {
                Console.WriteLine("\n Oyun Berabere...");
            }

            return sayac;
        }


    }
}

