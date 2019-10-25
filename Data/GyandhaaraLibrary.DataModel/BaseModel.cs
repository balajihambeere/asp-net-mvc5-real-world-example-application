namespace GyandhaaraLibrary.DataModel
{
    using System;

    public class BaseModel
    {
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int LastModifieldBy { get; set; }
    }
}
