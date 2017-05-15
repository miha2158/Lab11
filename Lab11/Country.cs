namespace Lab11
{
    abstract class Country
    {
        private string NameValue;
        protected string Name
        {
            get => NameValue;
            set => NameValue = value.Trim().ToLower();
        }

        protected int Population;

        private string ContinentValue;
        protected string Continent
        {
            get => ContinentValue;
            set => ContinentValue = value.Trim().ToLower();
        }

        private string RulerValue;
        protected string Ruler
        {
            get => RulerValue;
            set => RulerValue = value.Trim().ToLower();
        }

    }
}