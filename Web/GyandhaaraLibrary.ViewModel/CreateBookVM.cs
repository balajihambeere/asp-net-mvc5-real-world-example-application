using GyandhaaraLibrary.ViewModel.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GyandhaaraLibrary.ViewModel
{
    public class CreateBookVM
    {
        public CreateBookVM()
        {
            Genres = new List<GenreDropDownVM>();
            Languages = new List<LanguageDropDownVM>();
            Suppliers = new List<SupplierDropDownVM>();
        }

        [Required]
        public int BookID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} Required.")]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} Required.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} Required.")]
        [Display(Name = "Book Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} Required.")]
        [Display(Name = "ISBN Number")]
        public string Isbn { get; set; }

        [Required]
        [Display(Name = "Total Pages")]
        public int? TotalPages { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} Required.")]
        [Display(Name = "Edition")]
        public string Edition { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} Required.")]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal? Price { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} Required.")]
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }

        [Required]
        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime? PublishDate { get; set; }

        [Required]
        [Display(Name = "Purchased By")]
        public string PurchasedBy { get; set; }

        [Required]
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime? EntryDate { get; set; }

        [Required]
        [Display(Name = "Rack Number")]
        public int? RackNumber { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public IList<GenreDropDownVM> Genres { get; set; }

        [Required]
        [Display(Name = "Language")]
        public IList<LanguageDropDownVM> Languages { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public IList<SupplierDropDownVM> Suppliers { get; set; }

        // GenreID Foregin Kei
        public int? GenreID { get; set; }

        // LanguageID Foregin Key
        public int? LanguageID { get; set; }

        //SupplierID Foregin Key
        public int? SupplierID { get; set; }

        //PhotoID Foregin Key
        public int? PhotoID { get; set; }

        public PhotoViewModel Photo { get; set; }
    }
}
