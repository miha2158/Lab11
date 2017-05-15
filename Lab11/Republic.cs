using System.Linq;

namespace Lab11
{
    class Republic : Country
    {
        string[] Parlament = new string[0];

        public Republic(string Continent, int Population, string Name,
            string Ruler, string[] Parlament)
        {
            this.Continent = Continent;
            this.Population = Population;
            this.Name = Name;
            this.Ruler = Ruler;
            this.Parlament = Parlament;
        }
    }
}