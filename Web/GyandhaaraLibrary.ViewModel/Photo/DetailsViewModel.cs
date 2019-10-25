using System;

namespace GyandhaaraLibrary.ViewModel.Photo
{
    public class ViewBookViewModel
    {
        public int PhotoID { get; set; }
        public byte[] Image { get; set; }

        public int BookID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TotalPages { get; set; }
        public string Edition { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
    }
}
