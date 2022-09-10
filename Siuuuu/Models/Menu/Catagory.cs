using System.Collections.Generic;

namespace Siuuuu.Models.Menu
{
    public class Catagory
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
