using Siuuuu.Models.HomePage;
using System.Collections.Generic;

namespace Siuuuu.Vm
{
    public class HomePageVm
    {
        public List<HomeBestFood> food { get; set; }
        public List< HomeDescriptionOne> descriptionOne { get; set; }
        public List< HomeImageTwo> homeImageTwo { get; set; }
        public List< HomeImageOne> homeImageOne { get; set; }

        public List< HomeMainImage> homeMainImage { get; set; }
        public List< HomeManifestDescriptionn> homeManifestDescriptionn { get; set; }
        public List< HomeTxt1> homeTxt1 { get; set; }
        public List<HomeTxt2> homeTxt2 { get; set; }
        public List< HomeIcon> homeIcon { get; set; }
    }
}
