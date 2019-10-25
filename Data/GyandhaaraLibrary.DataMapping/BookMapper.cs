using GyandhaaraLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.DataMapping
{
    public class BookMapper : EntityTypeConfiguration<Book>
    {
        private readonly string schemaName = "Library";

        public BookMapper()
        {
            //To explicitly set a property to be a primary key, you can use the HasKey method
            HasKey(x => x.BookID);
            Property(t => t.Title).IsRequired().HasMaxLength(100);
            Property(t => t.Code).IsRequired().HasMaxLength(100);
            Property(t => t.Description).HasMaxLength(100);
            Property(t => t.Isbn).IsRequired().HasMaxLength(100);
            Property(t => t.Edition).IsRequired().HasMaxLength(50);
            Property(t => t.Author).IsRequired().HasMaxLength(50);
            Property(t => t.Publisher).IsRequired().HasMaxLength(50);
            Property(t => t.TotalPages).IsRequired();
            Property(t => t.Price).IsRequired();
            Property(t => t.PublishDate).IsRequired();
            Property(t => t.EntryDate).IsRequired();
            HasOptional(s => s.Genre);
            HasOptional(s => s.Supplier);
            HasOptional(s => s.Photo);
            HasOptional(s => s.Language);

            // Table and relationships 
            ToTable("Book", schemaName);
        }
    }
}
