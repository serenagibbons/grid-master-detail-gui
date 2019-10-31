using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_GridMasterDetail
{
    public class Movie
    {
        public string Name { get; set; }
        public string RottenTomatoScore { get; set; }
        public string Review { get; set; }
        public string ImageFile { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
