using Siuuuu.Models.Adres;
using Siuuuu.Models.Buy;
using Siuuuu.ViewModel;
using System.Collections.Generic;

namespace Siuuuu.Vm
{
    public class OrderPageVm
    {
        public Adres adres { get; set; }
        public List< BuyProductCount> buyProduct { get; set; }
    }
}
