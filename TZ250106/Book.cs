﻿namespace TZ250106;

internal class Book
{
    
    private long isbn;
    private List<Author> szerzok = [];
    private string cim;
    private int kiadasEve;
    private string nyelv;
    private int keszlet;
    private int ar;

    public long ISBN
    {
        get => isbn; set
        {
            if (value.ToString().Length != 10) throw new Exception("Nem megfelelő értéket adtál meg! (ISBN)");
            isbn = value;
        }
    }
    public List<Author> Szerzok { get => szerzok; set => szerzok = value; }
    public string Cim
    {
        get => cim; set
        {
            if (value.Length < 3 || value.Length > 64) throw new Exception("Nem megfelelő hosszúságu a cím!");
            cim = value;
        }
    }
    public int KiadasEve
    {
        get => kiadasEve; set
        {
            if (value < 1970 || value > DateTime.Now.Year) throw new Exception("Nem megfelelő értéket adtál meg! (Kiadás éve)");
            kiadasEve = value;
        }
    }
    public string Nyelv
    {
        get => nyelv; set
        {
            if (value != "angol" && value != "német" && value != "magyar") throw new Exception("Nem megfelelő értéket adtál meg! (Nyelv)");
            nyelv = value;
        }
    }
    public int Keszlet
    {
        get => keszlet; set
        {
            if (value < 0) throw new Exception("Nem megfelelő értéket adtál meg! (Készlet)");
            keszlet = value;
        }
    }
    public int Ar
    {
        get => ar; set
        {
            if (value < 1000 || value > 10000 || value % 100 != 0) throw new Exception("Nem megfelelő értéket adtál meg! (Ár)");
            ar = value;
        }
    }

    public Book(long isbn, string cim, int kiadasEve, string nyelv, int keszlet, int ar, params string[] szerzok)
    {
        ISBN = isbn;

        Cim = cim;
        KiadasEve = kiadasEve;
        Nyelv = nyelv;
        Keszlet = keszlet;
        Ar = ar;

        foreach (var szerzo in szerzok)
        {
            Szerzok.Add(new Author(szerzo));
        }
    }

    public long randomISBN()
    {
        Random random = new Random();

        

        int r1 = random.Next(1000000000, 999999999); 
        int r2 = random.Next(0, 9); 
        return Convert.ToInt64($"{r1}{r2}");
    }
    public Book(string cim, string szerzo)
    {
        ISBN = randomISBN();
        Cim = cim;
        KiadasEve = 2024;
        Nyelv = "magyar";
        Keszlet = 0;
        Ar = 4500;

        Szerzok.Add(new Author(szerzo));
    }

    private string konyvSzerzok()
    {
        string szerzok = "";
        foreach (var szerzo in Szerzok)
        {
            szerzok += $"{szerzo.VezetekNev} {szerzo.KeresztNev}, ";
        }
        
        if (szerzok.Length > 2)
        {
            szerzok = szerzok.Substring(0, szerzok.Length - 2);
        }
        return szerzok;
    }
    private string beszerzesKeszlet()
    {
        if (Keszlet == 0) { return "beszerzés alatt"; }
        else { return Convert.ToString(Keszlet); }
    }

    public override string ToString() =>
        $"{ISBN} - {Cim}\n" +
        $" {(Szerzok.Count == 1 ? "Szerző: " : "Szerzők: ") + konyvSzerzok()}\n" +
        $" {KiadasEve} - {Nyelv} nyelven\n" +
        $" Készleten: {beszerzesKeszlet()}\n" +
        $" Ára: {Ar}\n";
}
