using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.DataModel
{
    public class Supplier : BaseModel
    {
        public Supplier()
        {
        }
        public int SupplierID { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        // Foreign key 
        public int? AddressID { get; set; }

        // Navigation properties 
        public virtual Address Address { get; set; }
    }
}
