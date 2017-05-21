using System;
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

    public abstract class Country: IClone
    {
        private string NameValue;
        public string Name
        {
            get => NameValue;
            set => NameValue = value.Trim().ToLower();
        }

        public ulong Population;

        private string ContinentValue;
        public string Continent
        {
            get => ContinentValue;
            set => ContinentValue = value.Trim().ToLower();
        }

        private string RulerValue;
        public string Ruler
        {
            get => RulerValue;
            set => RulerValue = value.Trim().ToLower();
        }

        public abstract object Clone();

        public override string ToString ()
        {
            return Name + "; Правитель:" + Ruler + 
                "; Континент:" + Continent + "; Население:" + Population;
        }
    }
}
