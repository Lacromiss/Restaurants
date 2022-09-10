using Siuuuu.Models.Adres;
using Siuuuu.Models.Odemek;
using Siuuuu.ViewModel;

namespace Siuuuu.Vm
{
    public class PaidVm
    {
        public Detail detail { get; set; }
        public BuyProductCount buyProduct { get; set; }
        public Adres adres { get; set; }
    }
}
