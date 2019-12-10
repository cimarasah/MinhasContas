using System;

namespace MinhasContas.DAL.Interface.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
