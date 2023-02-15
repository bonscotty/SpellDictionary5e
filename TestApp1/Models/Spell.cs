namespace TestApp1.Models
{
    public class Spell : BaseModel
    {
        public spell_type SpellType { get; set; }
        public components Components { get; set; }
        public classes Classes { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Range { get; set; }
        public string Target { get; set; }
        public float Duration { get; set; }
        public string AtHigherLevels { get; set; }
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