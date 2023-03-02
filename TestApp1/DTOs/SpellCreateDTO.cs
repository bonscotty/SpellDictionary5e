using System.ComponentModel.DataAnnotations;


namespace TestApp1.DTOs
{
    public class SpellCreateDTO : BaseModelDTO
    {
        [Required]
        public string SpellType { get; set; }
        [Required]
        public string Components { get; set; }
        [Required]
        public string Classes { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int Range { get; set; }
        [Required]
        public string Target { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        public string AtHigherLevels { get; set; }
        [Required]
        public string MaterialComponents { get; set; }
    }
}