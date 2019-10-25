using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.ViewModel
{
    public class AddSupplierViewModel
    {
        public AddSupplierViewModel()
        {
            //AddressViewModel = new AddressViewModel();
        }
        public int SupplierID { get; set; }

        [Required]
        [Display(Name = "NAME")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "CONTACT")]
        public string Contact { get; set; }

        [Required]
        [Display(Name = "EMAIL")]
        public string Email { get; set; }

        [Required]
        public int AddressID { get; set; }

        [Required]
        [Display(Name = "STREET")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "CITY")]
        public string City { get; set; }

        [Required]
        [Display(Name = "STATE")]
        public string State { get; set; }

        [Required]
        [Display(Name = "COUNTRY")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "ZIPCODE")]
        public string ZipCode { get; set; }
        //public AddressViewModel AddressViewModel { get; set; }
    }
}
