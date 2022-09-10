using System.Collections.Generic;

namespace Siuuuu.Vm
{

    public class PaginationVm<T>
    {
        public List<T> Item { get; set; }
        public int PageCount { get; set; }
        public int ActivPage { get; set; }

    }

}