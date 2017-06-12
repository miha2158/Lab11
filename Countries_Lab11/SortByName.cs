using System.Collections;
using System.Collections.Generic;

namespace Countries_Lab11
{
    public class SortByName:IComparer
    {
        public SortByName()
        {
            
        }

        public int Compare(object x, object y)
        {
            var xx = x as Country;
            var yy = y as Country;
            return string.Compare(xx?.Name, yy?.Name);
        }
    }
}