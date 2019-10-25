using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.ViewModel.Photo
{
    public class PhotoViewModel
    {
        public int PhotoID { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }
    }
}
