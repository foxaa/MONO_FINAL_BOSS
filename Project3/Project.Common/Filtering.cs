using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public class Filtering
    {
        public string SearchParam { get; set; }
        public Filtering(string searchString)
        {
            SearchParam = searchString;
        }
    }
}
