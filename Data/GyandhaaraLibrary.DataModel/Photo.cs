using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.DataModel
{
    public class Photo : BaseModel
    {
        public int PhotoID { get; set; }
        public byte[] Image { get; set; }
        public string FileName { get; set; }
    }
}
