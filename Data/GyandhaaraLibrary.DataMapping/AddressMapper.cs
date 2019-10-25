using GyandhaaraLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.DataMapping
{
    public class AddressMapper : EntityTypeConfiguration<Address>
    {
        private readonly string schemaName = "Library";
        public AddressMapper()
        {
            HasKey(x => x.AddressID);
            Property(t => t.Street).IsRequired().HasMaxLength(50);
            Property(t => t.City).IsRequired().HasMaxLength(50);
            Property(t => t.State).IsRequired().HasMaxLength(50);
            Property(t => t.Country).IsRequired().HasMaxLength(50);
            Property(t => t.ZipCode).HasMaxLength(50);

            // Table and relationships 
            ToTable("Address", schemaName);
        }
    }
}
