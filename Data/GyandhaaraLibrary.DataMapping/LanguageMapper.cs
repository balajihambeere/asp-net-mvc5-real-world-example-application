using GyandhaaraLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.DataMapping
{
    public class LanguageMapper : EntityTypeConfiguration<Language>
    {
        private readonly string schemaName = "Library";
        public LanguageMapper()
        {
            HasKey(x => x.LanguageID);
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.Description).HasMaxLength(100);
            // Table and relationships 
            ToTable("Language", schemaName);
        }
    }
}
