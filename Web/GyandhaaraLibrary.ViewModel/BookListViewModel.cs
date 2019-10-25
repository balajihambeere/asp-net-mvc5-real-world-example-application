using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.ViewModel
{
    public class BookListViewModel
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Edition { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
    }
}
