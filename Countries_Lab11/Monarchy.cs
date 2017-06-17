namespace Countries_Lab11
{
    public class Monarchy : Country
    {
        public Monarchy(string Continent, ulong Population, string Name, string Ruler): 
            base(Continent, Population, Name, Ruler)
        {
        }

        public new object Clone()
        {
            var result = new Monarchy(Continent,Population,Name,Ruler);
            return result;
        }
    }
}