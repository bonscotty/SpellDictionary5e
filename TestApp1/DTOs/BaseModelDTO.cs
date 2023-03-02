using System.ComponentModel.DataAnnotations;

namespace TestApp1.DTOs
{
    public class BaseModelDTO
    {
        public int ID { get; set; }
        public Guid GUID { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
