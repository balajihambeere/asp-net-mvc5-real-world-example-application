using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.DataModel
{
    public class Book : BaseModel
    {
        public Book()
        {
        }

        public int BookID { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Isbn { get; set; }

        public int TotalPages { get; set; }

        public string Edition { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public string Publisher { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime EntryDate { get; set; }

        public int RackNumber { get; set; }

        public string PurchasedBy { get; set; }

        // GenreID Foregin Kei
        public int? GenreID { get; set; }

        public virtual Genre Genre { get; set; }

        // LanguageID Foregin Key
        public int? LanguageID { get; set; }

        public virtual Language Language { get; set; }

        //SupplierID Foregin Key
        public int? SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }

        //PhotoID Foregin Key
        public int? PhotoID { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
