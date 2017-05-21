namespace Countries_Lab11
{
    public class Monarchy : Country
    {
        public Monarchy(string Continent, ulong Population, string Name, string Ruler)
        {
            this.Continent = Continent;
            this.Population = Population;
            this.Name = Name;
            this.Ruler = Ruler;
        }

        public override object Clone()
        {
            var result = new Monarchy(Continent,Population,Name,Ruler);
            return result;
        }
    }
}