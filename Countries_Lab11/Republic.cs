using System.Collections.Generic;
using System.Linq;

namespace Countries_Lab11
{
    public class Republic : Country
    {
        string[] Parlament = new string[0];

        public Republic(string Continent, ulong Population, string Name,
            string Ruler, string[] Parlament)
        {
            this.Continent = Continent;
            this.Population = Population;
            this.Name = Name;
            this.Ruler = Ruler;
            this.Parlament = Parlament;
        }

        public override object Clone()
        {
            var result = new Republic
                (Continent, Population, Name, Ruler, Parlament.ToArray());
            return result;
        }
    }
}