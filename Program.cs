using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kartOyunu
{
    class Program
    {
        public static bool oyuncu2OynasinMi = true, uygunKartvarMi = false;
        public static bool oyuncu3Durum2OynasinMi = false, oyuncu3Durum3OynasinMi = true, oyuncu2Durum3OynasinMi = false, senBasladinPcOynasinMi = false;
        public static string kartim, atilanSonKart = "yok";
        public static int turSayisi = 0, kimBaslasin = 0, ilkOyuncuMu = 0;
        static void Main(string[] args)
        {
            Random r = new Random();
            string[] tumKartlar = { "k1", "k2", "k3", "k4", "k5", "m1", "m2", "m3", "m4", "m5", "s1", "s2", "s3", "s4", "s5", "rd", "rd", "rd" };
            string[] kullanici = new string[6];
            string[] oyuncu2Kartlari = new string[6];
            string[] oyuncu3Kartlari = new string[6];
            int a = 0, b = 0, c = 0, turDurumu = 1;
            while (true)
            {
                if (a < 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int uretilen = r.Next(0, 18);
                        if (tumKartlar[uretilen] != "bos")
                        {
                            kullanici[a] = tumKartlar[uretilen];
                            tumKartlar[uretilen] = "bos";
                            a++;
                        }
                        else
                        {
                            i = i - 1;
                        }
                    }
                }
                else if (b < 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int uretilen = r.Next(0, 18);
                        if (tumKartlar[uretilen] != "bos")
                        {
                            oyuncu2Kartlari[b] = tumKartlar[uretilen];
                            tumKartlar[uretilen] = "bos";
                            b++;
                        }
                        else
                        {
                            i = i - 1;
                        }
                    }
                }
                else if (c < 6)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int uretilen = r.Next(0, 18);
                        if (tumKartlar[uretilen] != "bos")
                        {
                            oyuncu3Kartlari[c] = tumKartlar[uretilen];
                            tumKartlar[uretilen] = "bos";
                            c++;
                        }
                        else
                        {
                            i = i - 1;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            kimBaslasin = r.Next(1, 4);
            bool sonsozKartIste = true;

            if (kimBaslasin == 1)
            {
                Console.WriteLine("Oyuna sen başlıyorsun");
            }
            else if (kimBaslasin == 2)
            {
                Console.WriteLine("Oyuna 2.Oyuncu başlıyor");
            }
            else if (kimBaslasin == 3)
            {
                Console.WriteLine("Oyuna 3.Oyuncu başlıyor");
            }
            Console.WriteLine();
            Console.WriteLine("Senin kartların");
            foreach (var item in kullanici)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1.Tur");
            while (sonsozKartIste == true)
            {
                if (kimBaslasin == 1)
                {
                    benimKartlar(kullanici);
                    Console.Write(" -- Kart At = ");
                    kartim = Console.ReadLine();
                    if ((kartim == "pas" || kartim == "rd") && turSayisi <= 0)
                    {
                        Console.WriteLine("İlk elden pas veya renk değiştirme kullanamazsın");
                        senBasladinPcOynasinMi = false;
                    }
                    else if (kartim == "pas")
                    {
                        Console.WriteLine("Pas verdin kart = " + atilanSonKart);
                        senBasladinPcOynasinMi = true;
                    }
                    else if (kartim == "rd")
                    {
                        int rdNerde = 0;
                        bool rdVarYok = false;
                        for (int rd = 0; rd < 6; rd++)
                        {
                            if (kullanici[rd] == "rd")
                            {
                                rdNerde = rd;
                                rdVarYok = true;
                            }
                        }
                        if (rdVarYok == true)
                        {
                            while (true)
                            {
                                Console.Write("Renk belirleyiniz : ");
                                string yeniRenk = Console.ReadLine();
                                if (yeniRenk == "m")
                                {
                                    atilanSonKart = "m" + atilanSonKart.Substring(1, 1);
                                    Console.WriteLine("Son kart = " + atilanSonKart);
                                    kullanici[rdNerde] = "yok";
                                    senBasladinPcOynasinMi = true;
                                    break;
                                }
                                else if (yeniRenk == "k")
                                {
                                    atilanSonKart = "k" + atilanSonKart.Substring(1, 1);
                                    Console.WriteLine("Son kart = " + atilanSonKart);
                                    kullanici[rdNerde] = "yok";
                                    senBasladinPcOynasinMi = true;
                                    break;
                                }
                                else if (yeniRenk == "s")
                                {
                                    atilanSonKart = "s" + atilanSonKart.Substring(1, 1);
                                    Console.WriteLine("Son kart = " + atilanSonKart);
                                    kullanici[rdNerde] = "yok";
                                    senBasladinPcOynasinMi = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı renk girişi");
                                    senBasladinPcOynasinMi = false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Elinizde rd kartı yok." + " yerdeki kart = " + atilanSonKart);
                            senBasladinPcOynasinMi = false;
                        }
                    }
                    else
                    {
                        if (turSayisi > 0)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (kullanici[j] == kartim)
                                {
                                    if (kullanici[j].Substring(0, 1) == atilanSonKart.Substring(0, 1) || kullanici[j].Substring(1, 1) == atilanSonKart.Substring(1, 1))
                                    {
                                        turSayisi++;

                                        atilanSonKart = kartim;
                                        kullanici[j] = "yok";
                                        senBasladinPcOynasinMi = true;
                                        break;
                                    }
                                }
                            }
                            if (senBasladinPcOynasinMi == false)
                            {
                                Console.WriteLine("Elinizde bu kart yok veya uygunsuz bir kart attınız." + " yerdeki kart = " + atilanSonKart);
                                senBasladinPcOynasinMi = false;
                            }

                        }
                        else
                        {
                            for (int j = 0; j < 6; j++)
                            {

                                if (kullanici[j] == kartim)
                                {
                                    turSayisi++;

                                    atilanSonKart = kartim;
                                    kullanici[j] = "yok";
                                    senBasladinPcOynasinMi = true;
                                    break;
                                }
                            }
                        }
                    }
                    bool kontrol = false;
                    kontrol = oyunBittiMi(kullanici);
                    if (kontrol == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Oyun Bitti kazanan SEN");
                        kalanKartlar(kullanici, oyuncu2Kartlari, oyuncu3Kartlari);
                        break;
                    }
                    if (senBasladinPcOynasinMi == true)
                    {
                        bilgisayarKartAt(oyuncu2Kartlari, "OYUNCU 2");
                        bool kontrol2 = false;
                        kontrol2 = oyunBittiMi(oyuncu2Kartlari);
                        if (kontrol2 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Oyun Bitti kazanan 2.Oyuncu");
                            kalanKartlar(kullanici, oyuncu2Kartlari, oyuncu3Kartlari);
                            break;
                        }
                        bilgisayarKartAt(oyuncu3Kartlari, "OYUNCU 3");
                        bool kontrol3 = false;
                        kontrol3 = oyunBittiMi(oyuncu3Kartlari);
                        if (kontrol3 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Oyun Bitti Kazanan 3.Oyuncu");
                            kalanKartlar(kullanici, oyuncu2Kartlari, oyuncu3Kartlari);
                            break;
                        }
                        senBasladinPcOynasinMi = false;
                        Console.WriteLine();
                        turDurumu++;
                        Console.WriteLine((turDurumu) + ".Tur");
                    }


                }


                else if (kimBaslasin == 2)
                {
                    if (oyuncu2OynasinMi == true)
                    {
                        bilgisayarKartAt(oyuncu2Kartlari, "OYUNCU 2");
                        bool kontrol1 = false;
                        kontrol1 = oyunBittiMi(oyuncu2Kartlari);
                        if (kontrol1 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Oyun Bitti Kazanan 2.Oyuncu");
                            kalanKartlar(kullanici, oyuncu2Kartlari, oyuncu3Kartlari);
                            break;
                        }
                        ilkOyuncuMu = 0;
                        oyuncu2OynasinMi = false;
                        oyuncu3Durum2OynasinMi = false;
                    }
                    benimKartlar(kullanici);
                    Console.Write(" -- Kart At = ");
                    kartim = Console.ReadLine();
                    if ((kartim == "pas" || kartim == "rd") && turSayisi <= 0 && ilkOyuncuMu == 1)
                    {
                        Console.WriteLine("İlk elden pas veya renk değiştirme kullanamazsın");
                        oyuncu3Durum2OynasinMi = false;
                    }
                    else if (kartim == "pas")
                    {
                        Console.WriteLine("Pas verdin kart. yerde ki kart = " + atilanSonKart);
                        oyuncu3Durum2OynasinMi = true;
                    }
                    else if (kartim == "rd")
                    {
                        int rdNerde = 0;
                        bool rdVarYok = false;
                        for (int rd = 0; rd < 6; rd++)
                        {
                            if (kullanici[rd] == "rd")
                            {
                                rdNerde = rd;
                                rdVarYok = true;
                            }
                        }
                        if (rdVarYok == true)
                        {
                            while (true)
                            {
                                Console.Write("Renk belirleyiniz : ");
                                string yeniRenk = Console.ReadLine();
                                if (yeniRenk == "m")
                                {
                                    atilanSonKart = "m" + atilanSonKart.Substring(1, 1);
                                    Console.WriteLine("Son kart = " + atilanSonKart);
                                    kullanici[rdNerde] = "yok";
                                    oyuncu3Durum2OynasinMi = true;
                                    break;
                                }
                                else if (yeniRenk == "k")
                                {
                                    atilanSonKart = "k" + atilanSonKart.Substring(1, 1);
                                    Console.WriteLine("Son kart = " + atilanSonKart);
                                    kullanici[rdNerde] = "yok";
                                    oyuncu3Durum2OynasinMi = true;
                                    break;
                                }
                                else if (yeniRenk == "s")
                                {
                                    atilanSonKart = "s" + atilanSonKart.Substring(1, 1);
                                    Console.WriteLine("Son kart = " + atilanSonKart);
                                    kullanici[rdNerde] = "yok";
                                    oyuncu3Durum2OynasinMi = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı renk girişi");
                                    oyuncu3Durum2OynasinMi = false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Elinizde rd kartı yok." + " yerdeki kart = " + atilanSonKart);
                            oyuncu3Durum2OynasinMi = false;
                        }
                    }
                    else
                    {
                        if (turSayisi > 0)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (kullanici[j] == kartim)
                                {
                                    if (kullanici[j].Substring(0, 1) == atilanSonKart.Substring(0, 1) || kullanici[j].Substring(1, 1) == atilanSonKart.Substring(1, 1))
                                    {
                                        turSayisi++;

                                        atilanSonKart = kartim;
                                        kullanici[j] = "yok";
                                        oyuncu3Durum2OynasinMi = true;
                                        break;
                                    }
                                }
                            }
                            if (oyuncu3Durum2OynasinMi == false)
                            {
                                Console.WriteLine("Elinizde bu kart yok veya uygunsuz bir kart attınız." + " yerdeki kart = " + atilanSonKart);
                                oyuncu3Durum2OynasinMi = false;
                            }

                        }
                        else
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (kullanici[j] == kartim)
                                {
                                    if (kartim.Substring(0, 1) == atilanSonKart.Substring(0, 1) || kartim.Substring(1, 1) == atilanSonKart.Substring(1, 1))
                                    {
                                        turSayisi++;

                                        atilanSonKart = kartim;
                                        kullanici[j] = "yok";
                                        oyuncu3Durum2OynasinMi = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    bool kontrol = false;
                    kontrol = oyunBittiMi(kullanici);
                    if (kontrol == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Oyun Bitti kazanan SEN");
                        kalanKartlar(kullanici, oyuncu2Kartlari, oyuncu3Kartlari);
                        break;
                    }
                    if (oyuncu3Durum2OynasinMi == true)
                    {
                        bilgisayarKartAt(oyuncu3Kartlari, "OYUNCU 3");
                        Console.WriteLine();
                        bool kontrol2 = false;
                        kontrol2 = oyunBittiMi(oyuncu3Kartlari);
                        if (kontrol2 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Oyun Bitti kazanan 3.Oyuncu");
                            kalanKartlar(kullanici, oyuncu2Kartlari, oyuncu3Kartlari);
                            break;
                        }
                        turDurumu++;
                        Console.WriteLine((turDurumu) + ".Tur");
                        oyuncu2OynasinMi = true;
                    }

                }


                else if (kimBaslasin == 3)
                {
                    if (oyuncu3Durum3OynasinMi == true)
                    {
                        bilgisayarKartAt(oyuncu3Kartlari, "OYUNCU 3");
                        bool kontrol1 = false;
                        kontrol1 = oyunBittiMi(oyuncu3Kartlari);
                        if (kontrol1 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Oyun Bitti kazanan 3.Oyuncu");
                            kalanKartlar(kullanici, oyuncu2Kartlari, oyuncu3Kartlari);
                            break;
                        }
                        oyuncu3Durum3OynasinMi = false
                            ;
                    }
                    benimKartlar(kullanici);
                    Console.Write(" -- Kart At = ");
                    kartim = Console.ReadLine();
                    if ((kartim == "pas" || kartim == "rd") && turSayisi <= 0 && kimBaslasin == 1)
                    {
                        Console.WriteLine("İlk elden pas veya renk değiştirme kullanamazsın");
                    }
                    else if (kartim == "pas")
                    {
                        Console.WriteLine("Pas verdin kart = " + atilanSonKart);
                        oyuncu2Durum3OynasinMi = true;
                    }
                    else if (kartim == "rd")
                    {
                        int rdNerde = 0;
                        bool rdVarYok = false;
                        for (int rd = 0; rd < 6; rd++)
                        {
                            if (kullanici[rd] == "rd")
                            {
                                rdNerde = rd;
                                rdVarYok = true;
                            }
                        }
                        if (rdVarYok == true)
                        {
                            while (true)
                            {
                                Console.Write("Renk belirleyiniz : ");
                                string yeniRenk = Console.ReadLine();
                                if (yeniRenk == "m")
                                {
                                    atilanSonKart = "m" + atilanSonKart.Substring(1, 1);
                                    Console.WriteLine("Son kart = " + atilanSonKart);
                                    kullanici[rdNerde] = "yok";
                                    oyuncu2Durum3OynasinMi = true;
                                    break;
                                }
                                else if (yeniRenk == "k")
                                {
                                    atilanSonKart = "k" + atilanSonKart.Substring(1, 1);
                                    Console.WriteLine("Son kart = " + atilanSonKart);
                                    kullanici[rdNerde] = "yok";
                                    oyuncu2Durum3OynasinMi = true;
                                    break;
                                }
                                else if (yeniRenk == "s")
                                {
                                    atilanSonKart = "s" + atilanSonKart.Substring(1, 1);
                                    Console.WriteLine("Son kart = " + atilanSonKart);
                                    kullanici[rdNerde] = "yok";
                                    oyuncu2Durum3OynasinMi = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Hatalı renk girişi");
                                    oyuncu2Durum3OynasinMi = false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Elinizde rd kartı yok." + " yerdeki kart = " + atilanSonKart);
                            oyuncu2Durum3OynasinMi = false;
                        }
                    }
                    else
                    {
                        if (turSayisi > 0)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (kullanici[j] == kartim)
                                {
                                    if (kullanici[j].Substring(0, 1) == atilanSonKart.Substring(0, 1) || kullanici[j].Substring(1, 1) == atilanSonKart.Substring(1, 1))
                                    {
                                        turSayisi++;

                                        atilanSonKart = kartim;
                                        kullanici[j] = "yok";
                                        oyuncu2Durum3OynasinMi = true;
                                        break;
                                    }
                                }
                            }
                            if (oyuncu2Durum3OynasinMi == false)
                            {
                                Console.WriteLine("Elinizde bu kart yok veya uygunsuz bir kart attınız." + " yerdeki kart = " + atilanSonKart);
                            }

                        }
                        else
                        {
                            for (int j = 0; j < 6; j++)
                            {

                                if (kullanici[j] == kartim)
                                {
                                    if (kartim.Substring(0, 1) == atilanSonKart.Substring(0, 1) || kartim.Substring(1, 1) == atilanSonKart.Substring(1, 1))
                                    {
                                        turSayisi++;
                                        atilanSonKart = kartim;
                                        kullanici[j] = "yok";
                                        oyuncu2Durum3OynasinMi = true;
                                        break;
                                    }
                                }
                            }
                            if (oyuncu2Durum3OynasinMi == false)
                            {
                                Console.WriteLine("Elinizde bu kart yok veya uygunsuz bir kart attınız." + " yerdeki kart = " + atilanSonKart);
                            }
                        }
                    }
                    bool kontrol = false;
                    kontrol = oyunBittiMi(kullanici);
                    if (kontrol == true)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Oyun Bitti kazanan SEN");
                        kalanKartlar(kullanici, oyuncu2Kartlari, oyuncu3Kartlari);
                        break;
                    }
                    if (oyuncu2Durum3OynasinMi == true)
                    {
                        bilgisayarKartAt(oyuncu2Kartlari, "OYUNCU 2");
                        Console.WriteLine();
                        bool kontrol2 = false;
                        kontrol2 = oyunBittiMi(oyuncu2Kartlari);
                        if (kontrol2 == true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Oyun Bitti kazanan 2.Oyuncu");
                            kalanKartlar(kullanici, oyuncu2Kartlari, oyuncu3Kartlari);
                            break;
                        }
                        oyuncu3Durum3OynasinMi = true;
                        turDurumu++;
                        Console.WriteLine((turDurumu) + ".Tur");

                    }
                }
            }
            Console.ReadLine();
        }
        public static void bilgisayarKartAt(string[] pcKartlar, string pcOyuncu)
        {
            bool pcUygunKart = false, rdVarMi = false;
            int rdIndis = 0;
            if (atilanSonKart == "yok")
            {
                for (int i = 0; i < 6; i++)
                {
                    if (pcKartlar[i] != "rd")
                    {
                        Console.WriteLine(pcOyuncu + " " + pcKartlar[i]);
                        atilanSonKart = pcKartlar[i];
                        pcKartlar[i] = "yok";
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (pcKartlar[i].Substring(0, 1) == atilanSonKart.Substring(0, 1) || pcKartlar[i].Substring(1, 1) == atilanSonKart.Substring(1, 1))
                    {
                        pcUygunKart = true;
                        Console.WriteLine(pcOyuncu + " " + pcKartlar[i]);
                        atilanSonKart = pcKartlar[i];
                        pcKartlar[i] = "yok";
                        break;
                    }
                }
                if (pcUygunKart == false)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (pcKartlar[i] == "rd")
                        {
                            rdIndis = i;
                            rdVarMi = true;
                            break;
                        }
                    }

                    if (rdVarMi == true)
                    {
                        bool eldeRenkliKartYok = false;
                        for (int i = 0; i < 6; i++)
                        {
                            if (pcKartlar[i].Substring(0, 1) == "k")
                            {
                                atilanSonKart = "k" + atilanSonKart.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni kartı " + atilanSonKart + " yaptı");
                                pcKartlar[rdIndis] = "yok";
                                eldeRenkliKartYok = true;
                                break;
                            }
                            else if (pcKartlar[i].Substring(0, 1) == "m")
                            {
                                atilanSonKart = "m" + atilanSonKart.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni kartı " + atilanSonKart + " yaptı");
                                pcKartlar[rdIndis] = "yok";
                                eldeRenkliKartYok = true;
                                break;
                            }
                            else if (pcKartlar[i].Substring(0, 1) == "s")
                            {
                                atilanSonKart = "s" + atilanSonKart.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni kartı " + atilanSonKart + " yaptı");
                                pcKartlar[rdIndis] = "yok";
                                eldeRenkliKartYok = true;
                                break;
                            }
                        }
                        if (eldeRenkliKartYok == false)
                        {
                            Random r = new Random();
                            int renkUret = r.Next(0, 3);
                            if (renkUret == 0)
                            {
                                atilanSonKart = "m" + atilanSonKart.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni kartı " + atilanSonKart + " yaptı");

                            }
                            else if (renkUret == 1)
                            {
                                atilanSonKart = "k" + atilanSonKart.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni kartı " + atilanSonKart + " yaptı");

                            }
                            else if (renkUret == 2)
                            {
                                atilanSonKart = "s" + atilanSonKart.Substring(1, 1);
                                Console.WriteLine(pcOyuncu + " RD kullanarak yeni kartı " + atilanSonKart + " yaptı");

                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine(pcOyuncu + " Pas verdi " + atilanSonKart);
                    }

                }
            }

        }
        public static bool oyunBittiMi(string[] kartDurum)
        {
            bool BittiMi = false;
            int kartSayisi = 0;
            for (int i = 0; i < 6; i++)
            {
                if (kartDurum[i] == "yok")
                {
                    kartSayisi++;
                }
            }
            if (kartSayisi >= 6)
            {
                BittiMi = true;
            }
            return BittiMi;
        }
        public static void benimKartlar(string[] kart)
        {
            foreach (var item in kart)
            {
                Console.Write(item + " ");
            }
        }
        public static void kalanKartlar(string[] kart1, string[] kart2, string[] kart3)
        {
            Console.WriteLine();
            Console.WriteLine("Senin kartların");
            foreach (var item in kart1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2.Oyuncu kartları");
            foreach (var item in kart2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("3.Oyuncu kartları");
            foreach (var item in kart3)
            {
                Console.Write(item + " ");
            }

        }
    }
}
