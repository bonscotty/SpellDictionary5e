using System.ComponentModel.DataAnnotations;

namespace TestApp1.DTOs
{
    public class SpellUpdateDto : BaseModelDTO
    {
        [Required]
        public spell_type SpellType { get; set; }
        [Required]
        public components Components { get; set; }
        [Required]
        public classes Classes { get; set; }
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
