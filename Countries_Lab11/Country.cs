using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries_Lab11
{
    public interface IClone
    {
        object Clone ();
    }

    public class Country: IClone, ICloneable, IComparable
    {
        public Country(string Continent,ulong Population, string Name, string Ruler)
        {
            this.Continent = Continent;
            this.Population = Population;
            this.Name = Name;
            this.Ruler = Ruler;
        }
        
        private string NameValue;
        public string Name
        {
            get { return NameValue; }
            set { NameValue = value.Trim().ToLower(); }
        }

        public ulong Population;

        private string ContinentValue;
        public string Continent
        {
            get { return ContinentValue; }
            set { ContinentValue = value.Trim().ToLower();}
        }

        private string RulerValue;
        public string Ruler
        {
            get { return RulerValue; }
            set { RulerValue = value.Trim().ToLower(); }
        }


        public override bool Equals(object obj)
        {
            return (CompareTo(obj) == 1);
        }

        public override int GetHashCode()
        {
            return ((decimal)Name.GetHashCode() + Population.GetHashCode() + Continent.GetHashCode() + Ruler.GetHashCode())
                .GetHashCode();
        }

        #region comparers
        
        public int CompareTo(object obj)
        {
            Country p = obj as Country;

            int c1 = string.Compare(Name, p?.Name);
            int c2 = string.Compare(Continent, p?.Continent);
            int c3 = string.Compare(Ruler, p?.Ruler);
            int c4 = Population.CompareTo(p?.Population);

            return c1 != 0 ? c1: c2 != 0 ? c2: c3 != 0 ? c3: c4;
        }

        #endregion

        public object Clone()
        {
            return new Country(Continent, Population,Name,Ruler);
        }

        public override string ToString ()
        {
            return Name + "; Правитель:" + Ruler + 
                "; Континент:" + Continent + "; Население:" + Population;
        }
    }
}
