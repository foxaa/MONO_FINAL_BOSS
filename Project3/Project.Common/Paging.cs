using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public class Paging
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public Paging(int pageNumber, int pageSize)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
