namespace TestApp1.DTOs
{
    public class SpellReadDTO
    {
        public string Name { get; set; }
        public string SpellType { get; set; }
        public string Description { get; set; }
        public string Components { get; set; }
        public string Classes { get; set; }
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