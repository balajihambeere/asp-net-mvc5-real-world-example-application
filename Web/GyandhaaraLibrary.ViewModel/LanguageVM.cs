using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.ViewModel
{
    public class LanguageVM
    {
        public int LanguageID { get; set; }

        [Required]
        [Display(Name = "LANGUAGE")]
        [RegularExpression("^[a-zA-Z- ]+$", ErrorMessage = "The {0}  must in alphabets")]
        public string Name { get; set; }

        [Display(Name = "DESCRIPTION")]
        [DataType(DataType.MultilineText)]
        [RegularExpression("^[a-zA-Z- ]+$", ErrorMessage = "The {0}  must in alphabets")]
        public string Description { get; set; }
    }
}
