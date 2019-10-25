using GyandhaaraLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.DataMapping
{
    public class PhotoMapper : EntityTypeConfiguration<Photo>
    {
        private readonly string schemaName = "Library";
        public PhotoMapper()
        {
            HasKey(x => x.PhotoID);
            Property(t => t.Image).IsRequired();
            Property(t => t.FileName).HasMaxLength(100);
            // Table and relationships 
            ToTable("Photo", schemaName);
        }
    }
}
