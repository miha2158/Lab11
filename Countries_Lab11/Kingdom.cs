namespace Countries_Lab11
{
    public class Kingdom : Monarchy
    {
        public string King
        {
            get { return Ruler; }
            set { Ruler = value; }
        }

        public Kingdom(string Continent, ulong Population, string Name, string King)
            : base(Continent, Population, Name, King) { }


        public new object Clone()
        {
            var result = new Kingdom(Continent, Population, Name, King);
            return result;
        }

    }
}