
using System;
using System.Collections.Generic;

namespace AdamAsmaca
{
    class Program
    {
        static void Main(string[] args)
        {
            string gizliKelime = "elazığ";  // Tahmin edilmesi gereken gizli kelime
            int tahminHakkin = 6;  // Kullanıcının kaç tahmin hakkı kaldığını takip eder
            char[] kelimeDurumu = new char[gizliKelime.Length];  // Kelimenin hangi harflerinin doğru tahmin edildiğini tutar

            // Kelimenin durumunu başlatıyoruz, tüm karakterleri başlangıçta '_' ile dolduruyoruz
            for (int i = 0; i < gizliKelime.Length; i++)
            {
                kelimeDurumu[i] = '_'; // Başlangıçta boş karakterler (alt çizgi ile temsil ediliyor)
            }

            // Tahmin döngüsüne girmeden önce kullanıcıdan harf almak için bir giriş alıyoruz
            while (tahminHakkin > 0 && !KelimeTamamlandi(kelimeDurumu))  // Tahmin hakkı bitmediği sürece ve kelime tamamlanmadığı sürece döngü devam eder
            {
                Console.Clear();  // Ekranı temizleriz, her adımda güncel durumu göstermek için
                CizAdam(tahminHakkin);  // Yanlış tahminlere göre adamı çizeriz
                Console.WriteLine($"Kalan tahmin hakkınız: {tahminHakkin}");  // Kalan tahmin hakkını gösterir
                Console.WriteLine("Kelime durumu: " + new string(kelimeDurumu));  // Kelimenin mevcut durumunu gösterir
                Console.Write("Bir harf tahmin edin: ");  // Kullanıcıdan bir harf girişi ister

                string input = Console.ReadLine();  // Kullanıcının tahminini almak için bir giriş alır

                if (!string.IsNullOrEmpty(input))  // Kullanıcının giriş yapıp yapmadığını kontrol ederiz
                {
                    char tahmin = input[0];  // Giriş boş değilse ilk karakterini alıyoruz
                    bool dogruTahmin = false;  // Tahminin doğru olup olmadığını takip ederiz

                    // Gizli kelime içinde tahmin edilen harfi arıyoruz
                    for (int i = 0; i < gizliKelime.Length; i++)
                    {
                        if (gizliKelime[i] == tahmin)  // Eğer tahmin edilen harf gizli kelimede varsa
                        {
                            kelimeDurumu[i] = tahmin;  // Kelimenin doğru yerine harfi yerleştiririz
                            dogruTahmin = true;  // Doğru tahmin olduğunu işaretleriz
                        }
                    }

                    if (!dogruTahmin)  // Eğer doğru tahmin edilmediyse
                    {
                        tahminHakkin--;  // Tahmin hakkını bir azaltırız
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen bir harf girin.");  // Boş giriş yapılırsa uyarı mesajı
                }
            }

            // Oyun bitimi, kullanıcı kelimeyi tamamlamış mı kontrol ediyoruz
            if (KelimeTamamlandi(kelimeDurumu))  // Eğer kelimenin tüm harfleri tahmin edildiyse
            {
                Console.WriteLine("Tebrikler, kelimeyi buldunuz!");  // Kazanma mesajı
            }
            else
            {
                Console.WriteLine("Tahmin hakkınız bitti, kaybettiniz!");  // Kayıp mesajı
                CizAdam(0);  // Kaybettikten sonra tam adamı göster
            }
        }

        // Kelimenin tamamlanıp tamamlanmadığını kontrol eden fonksiyon
        static bool KelimeTamamlandi(char[] kelimeDurumu)
        {
            foreach (char c in kelimeDurumu)
            {
                if (c == '_')  // Eğer hala boş (tahmin edilmemiş) karakterler varsa kelime tamamlanmamıştır
                {
                    return false;  // Henüz kelime tamamlanmadı
                }
            }
            return true;  // Tüm harfler tahmin edilmiş, kelime tamamlandı
        }

        // Adamı çizen fonksiyon
        static void CizAdam(int tahminHakkin)
        {
            if (tahminHakkin <= 5)
            {
                Console.WriteLine("   +---+");
                Console.WriteLine("   |   |");
            }
            else
            {
                Console.WriteLine("       +---+");
                Console.WriteLine("       |   |");
            }

            if (tahminHakkin <= 5)
                Console.WriteLine("   O   |");
            else
                Console.WriteLine("       |");

            if (tahminHakkin <= 4)
                Console.WriteLine("  /|   |");
            else if (tahminHakkin <= 3)
                Console.WriteLine("  /|\\  |");
            else
                Console.WriteLine("       |");

            if (tahminHakkin <= 2)
                Console.WriteLine("  /    |");
            else if (tahminHakkin <= 1)
                Console.WriteLine("  / \\  |");
            else
                Console.WriteLine("       |");

            Console.WriteLine("       |");
            Console.WriteLine("  =========");
        }
    }
}