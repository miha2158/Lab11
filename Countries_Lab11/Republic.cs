using System.Collections.Generic;
using System.Linq;

namespace Countries_Lab11
{
    public class Republic : Country
    {
        public string[] Parlament = new string[0];

        public Republic(string Continent, ulong Population, string Name,
            string Ruler, string[] Parlament): base(Continent,Population,Name,Ruler)
        {
            this.Parlament = Parlament;
        }

        public new object Clone()
        {
            var result = new Republic
                (Continent, Population, Name, Ruler, Parlament.ToArray());
            return result;
        }
    }
}