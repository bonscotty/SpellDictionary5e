namespace TestApp1.Models
{
    public class BaseModel
    {
        public Guid GUID { get; set; }
        public int ID { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
