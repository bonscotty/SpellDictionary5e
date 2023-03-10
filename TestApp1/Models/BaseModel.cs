using System.ComponentModel.DataAnnotations;

namespace TestApp1.Models
{
    public class BaseModelDTO
    {
        [Key]
        public int ID { get; set; }
        public Guid GUID { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
