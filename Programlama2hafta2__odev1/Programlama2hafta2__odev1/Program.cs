using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- STACK UYGULAMALARI ---");
            Console.WriteLine("1 - 1..n Sayı Toplamı");
            Console.WriteLine("2 - Kelimeyi Ters Çevir");
            Console.WriteLine("3 - Undo Sistemi");
            Console.WriteLine("4 - Peek İşlemi");
            Console.WriteLine("5 - Parantez Kontrolü");
            Console.WriteLine("0 - Çıkış");

            int secim = GuvenliIntAl("Seçiminiz: ");

            switch (secim)
            {
                case 1: SayiToplam(); break;
                case 2: KelimeTers(); break;
                case 3: UndoSistemi(); break;
                case 4: PeekOrnek(); break;
                case 5: ParantezKontrol(); break;
                case 0: return;
                default: Console.WriteLine("Hatalı seçim!"); break;
            }
        }
    }

    static int GuvenliIntAl(string mesaj)
    {
        int sayi;
        Console.Write(mesaj);

        while (!int.TryParse(Console.ReadLine(), out sayi))
        {
            Console.WriteLine("Hatalı giriş! Lütfen sayı gir.");
            Console.Write(mesaj);
        }

        return sayi;
    }

    // 1. Soru
    static void SayiToplam()
    {
        int n = GuvenliIntAl("n değerini gir: ");

        Stack<int> s = new Stack<int>();
        for (int i = 1; i <= n; i++)
            s.Push(i);

        int toplam = 0;
        while (s.Count > 0)
            toplam += s.Pop();

        Console.WriteLine("Toplam: " + toplam);
    }

    // 2. Soru
    static void KelimeTers()
    {
        Console.Write("Kelime gir: ");
        string kelime = Console.ReadLine();

        Stack<char> s = new Stack<char>();
        foreach (char c in kelime)
            s.Push(c);

        string ters = "";
        while (s.Count > 0)
            ters += s.Pop();

        Console.WriteLine("Ters: " + ters);
    }

    // 3. Soru
    static void UndoSistemi()
    {
        Stack<string> islemler = new Stack<string>();

        Console.WriteLine("İşlem gir (bitirmek için 'q'):");

        while (true)
        {
            string islem = Console.ReadLine();
            if (islem.ToLower() == "q") break;
            islemler.Push(islem);
        }

        Console.WriteLine("Undo yapılıyor...");
        while (islemler.Count > 0)
            Console.WriteLine("Geri alındı: " + islemler.Pop());
    }

    // 4. Soru
    static void PeekOrnek()
    {
        Stack<int> s = new Stack<int>();
        s.Push(3);

        for (int i = 0; i < 10; i++)
        {
            int ust = s.Peek();
            Console.WriteLine("Üstteki: " + ust);

            if (ust % 2 == 0)
            {
                Console.WriteLine("Çift → pop");
                s.Pop();
                if (s.Count == 0)
                    s.Push(1);
            }
            else
            {
                Console.WriteLine("Tek → push(" + (ust + 1) + ")");
                s.Push(ust + 1);
            }
        }
    }

    // 5. Soru
    static void ParantezKontrol()
    {
        Console.Write("Metin gir: ");
        string metin = Console.ReadLine();

        Stack<char> s = new Stack<char>();
        bool dengeli = true;

        foreach (char c in metin)
        {
            if (c == '(')
                s.Push(c);
            else if (c == ')')
            {
                if (s.Count == 0)
                {
                    dengeli = false;
                    break;
                }
                s.Pop();
            }
        }

        if (s.Count != 0)
            dengeli = false;

        Console.WriteLine(dengeli ? "Dengeli" : "Dengesiz");
    }
}