using System.ComponentModel.DataAnnotations;

namespace TestApp1.Models
{
    public class Spell : BaseModelDTO
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

    public enum spell_type 
    { 
        abjuration,
        alteration,
        conjuration,
        divination,
        enchantment,
        illusion,
        invocation,
        necromancy
    }

    public enum components
    { 
        V,
        S,
        M
    }

    public enum classes
    { 
        artificer,
        bard,
        cleric,
        druid,
        sorceror,
        warlock,
        wizard
    }
}