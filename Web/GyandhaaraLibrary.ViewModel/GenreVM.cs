using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.ViewModel
{
    public class GenreVM
    {
        public int GenreID { get; set; }

        [Required]
        [Display(Name = "GENRE")]
        [RegularExpression("^[a-zA-Z- ]+$", ErrorMessage = "The {0}  must in alphabets")]
        public string Name { get; set; }

        [Display(Name = "DESCRIPTION")]
        [DataType(DataType.MultilineText)]
        [RegularExpression("^[a-zA-Z- ]+$", ErrorMessage = "The {0}  must in alphabets")]
        public string Description { get; set; }

    }
}
