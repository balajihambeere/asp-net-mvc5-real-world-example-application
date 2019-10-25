using GyandhaaraLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.DataMapping
{
    public class SupplierMapper : EntityTypeConfiguration<Supplier>
    {
        private readonly string schemaName = "Library";
        public SupplierMapper()
        {
            //To explicitly set a property to be a primary key, you can use the HasKey method
            HasKey(x => x.SupplierID);
            Property(t => t.Name).IsRequired().HasMaxLength(100);
            Property(t => t.Contact).IsRequired().HasMaxLength(100);
            Property(t => t.Email).IsRequired().HasMaxLength(100);
            HasOptional(s => s.Address);

            // Table and relationships 
            ToTable("Supplier", schemaName);
        }
    }
}
