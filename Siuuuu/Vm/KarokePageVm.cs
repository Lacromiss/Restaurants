using Siuuuu.Models.Karoke;
using System.Collections.Generic;

namespace Siuuuu.Vm
{
    public class KarokePageVm
    {
        public List<KarokeConcept> karokeConcept { get; set; }
        public List<KarokeImage> karokeImage { get; set; }
        public List<KarokeInformation> karokeInformation { get; set; }
        public List<KarokeQuestion> karokeQuestion { get; set; }
        public List<KarokeRezerevation> karokeRezerevation { get; set; }
    }
}
