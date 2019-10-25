using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.ViewModel
{
    public class IndexSupplierVM
    {
        public int SupplierID { get; set; }

        [Required]
        [Display(Name = "NAME")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "CONTACT")]
        public string Contact { get; set; }

        [Required]
        [Display(Name = "EMAIL ADDRESS")]
        public string Email { get; set; }
    }
}
