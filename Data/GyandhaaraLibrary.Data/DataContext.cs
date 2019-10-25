using GyandhaaraLibrary.DataMapping;
using GyandhaaraLibrary.DataModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GyandhaaraLibrary.Data
{
    public class DataContext : DbContext
    {
        public IDbSet<Genre> Genre { get; set; }

        public IDbSet<Language> Language { get; set; }

        public IDbSet<Address> Address { get; set; }

        public IDbSet<Book> Book { get; set; }

        public IDbSet<Supplier> Supplier { get; set; }

        public IDbSet<Photo> Photo { get; set; }


        public DataContext() : base("DB.ConnectionString")
        {
            Genre = Set<Genre>();
            Language = Set<Language>();
            Address = Set<Address>();
            Book = Set<Book>();
            Supplier = Set<Supplier>();
            Photo = Set<Photo>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new GenreMapper());
            modelBuilder.Configurations.Add(new LanguageMapper());
            modelBuilder.Configurations.Add(new AddressMapper());
            modelBuilder.Configurations.Add(new SupplierMapper());
            modelBuilder.Configurations.Add(new PhotoMapper());
            modelBuilder.Configurations.Add(new BookMapper());
        }
    }
}
