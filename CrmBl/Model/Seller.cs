using System.Collections.Generic;

namespace CrmBl.Model
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Check> Checks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
