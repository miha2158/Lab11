using System;

namespace Lab11
{
    class Kingdom : Monarchy
    {
        protected string King
        {
            get => Ruler;
            set => Ruler = value.Trim().ToLower();
        }

        public Kingdom(string Continent, int Population, string Name, string King)
            : base(Continent, Population, Name, King) { }



    }
}