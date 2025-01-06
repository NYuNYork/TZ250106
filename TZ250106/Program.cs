using System;
using System.Collections.Generic;

namespace TZ250106
{
    public class Program
    {
        public static void Main()
        {

            List<Book> books = new List<Book>();
            for (int i = 0; i < 15; i++)
            {
                long isbn = randomISBN();
                while (books.Exists(b => b.ISBN == isbn))
                {
                    isbn = randomISBN();
                }

                List<string> szerzok = randomAuthors();
                string cim = randomTitle();
                int ev = randomYear();
                string nyelv = randomLanguage();
                int keszlet = randomStock();
                int ar = randomPrice();

                Book book = new Book(isbn, cim, ev, nyelv, keszlet, ar, szerzok.ToArray());
                books.Add(book);
            }


            foreach (var book in books)
            {
                Console.WriteLine(book);
            }


            int totalSold = 0;
            int totalSoldPrice = 0;
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                Console.WriteLine("\n");
                Console.WriteLine($"{i + 1}. emuláció kör".PadLeft((Console.WindowWidth + $"{i + 1}. emuláció kör".Length) / 2));
                Console.WriteLine("\n");

                Book book = books[random.Next(0, books.Count)];
                if (book.Keszlet > 0)
                {
                    book.Keszlet--;
                    totalSold++;
                    totalSoldPrice += book.Ar;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"1 darab {book.ISBN} - {book.Cim} sikeresen eladva {book.Ar} összegért. " +
                        $"\n\tEzzel {totalSold} lett az eddigi eladott könyvek száma" +
                        $"\n\tMelyeknek összértéke {totalSoldPrice}.-Ft");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Ebben a körben nem adtunk el könyvet! Várakozás a további emulációra...");
                    Console.ResetColor();
                    int chance = random.Next(1, 11);
                    if (chance <= 5)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Sikeres berendelés!");
                        int stock = random.Next(1, 11);
                        book.Keszlet += stock;
                        Console.WriteLine($"A készletet {stock} darabbal növeltük. Új készlet: {book.Keszlet}");
                        Console.ResetColor();
                    }
                    else if (books.Count != 0)
                    {
                        books.Remove(book);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"A {book.Cim} című könyvet már nem árusítják a nagykereskedelemben. Készleten lévő könyvek száma: {books.Count}");
                        Console.ResetColor();
                    }
                    else
                    {
                        NotImplementedException e = new NotImplementedException("Nincs több könyv a nagykerben!");
                    }
                }
            }
            Console.WriteLine("Az emuláció sikeresen befejeződött! Íme a részletes végeredmény:");
            Console.WriteLine($"\tAz eladásokból származó bevétel: {totalSoldPrice}.-Ft");
            Console.WriteLine($"\tA nagykerben maradt könyvek száma: {books.Count}");
            Console.WriteLine($"\tA raktárkészlet változása: {totalSold - books.Count}");
            Console.WriteLine($"\tA raktárkészlet jelenlegi állapota: {books.Count} db könyv");

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

        }
        public static long randomISBN()
        {
            Random random = new Random();
            int r1 = random.Next(100000000, 999999999);
            int r2 = random.Next(0, 9);
            return Convert.ToInt64($"{r1}{r2}");
        }
        public static List<string> randomAuthors()
        {
            Random random = new Random();


            int numAuthors;
            int chance = random.Next(1, 11);
            if (chance <= 7) numAuthors = 1;
            else numAuthors = random.Next(2, 4);

            List<string> authors = new List<string>();

            for (int i = 0; i < numAuthors; i++)
            {
                string[] AList = { "Cserepes Banánvirág", "Pöck Ödön", "Bud Izsák", "Ceruza Elemér", "Bac Ilus", "Görk Orsolya", "Kukija Kitsi", "Kuki Nuku" };
                string author = AList[random.Next(0, AList.Length)];
                authors.Add(author);
            }

            return authors;
        }

        public static string randomTitle()
        {
            Random random = new Random();
            string[] titlek = { "The Silent Night", "The Lost Time", "The Blue Lake", "The Secret Garden", "A csendes éj", "Az elveszett idő", "A kék tó", "A titkos kert" };
            return titlek[random.Next(0, titlek.Length)];

        }

        public static int randomYear()
        {
            Random random = new Random();
            int currentYear = DateTime.Now.Year;
            return random.Next(1970, currentYear + 1);
        }

        public static string randomLanguage()
        {
            Random random = new Random();
            string[] languages = { "magyar", "angol" };
            return languages[random.Next(0, 5) < 4 ? 0 : 1];
        }

        public static int randomStock()
        {
            Random random = new Random();
            int stock = random.Next(1, 11);
            int chance = random.Next(1, 11);

            if (chance <= 3)
            {
                stock = 0;
            }

            return stock;
        }

        public static int randomPrice()
        {
            Random random = new Random();
            int price = random.Next(10, 101) * 100;
            return price;
        }
    }


}
