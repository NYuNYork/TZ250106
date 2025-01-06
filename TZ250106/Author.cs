namespace TZ250106
{
    internal class Author
    {
        
        private string keresztNev;
        private string vezetekNev;
        private Guid guid;

        public string KeresztNev
        {
            get => keresztNev; set
            {
                if (value.Length < 3 || value.Length > 32) throw new Exception("Nem megfelelő hosszúságú a keresztnév!");
                keresztNev = value;
            }
        }
        public string VezetekNev
        {
            get => vezetekNev; set
            {
                if (value.Length < 3 || value.Length > 32) throw new Exception("Nem megfelelő hosszúságú a vezetéknév!");
                vezetekNev = value;
            }
        }
        public Guid Guid { get => guid; set => guid = value; }

        public Author(string nev)
        {
            Guid = Guid.NewGuid();
            string[] nevek = nev.Split(' ');
            VezetekNev = nevek[0];
            KeresztNev = nevek[1];
        }
    }
}
