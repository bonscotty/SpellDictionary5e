using Microsoft.EntityFrameworkCore;
using TestApp1.Models;

namespace TestApp1.Data
{
    public class SpellRepo : ISpellRepo
    {
        private readonly ApplicationDBContext _ctx;

        public SpellRepo(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateSpell(Spell spell)
        {
            if (spell == null) throw new ArgumentNullException(nameof(spell));
            await _ctx.AddAsync(spell);
        }

        public void DeleteSpell(int id)
        {
            if (id == 0) throw new ArgumentNullException(nameof(id));
            var spell = _ctx.Spells.FirstOrDefaultAsync(c => c.ID == id && c.IsDeleted != true);
            
            if (spell.Result != null) 
            {
                spell.Result.IsDeleted = true;
            }
        }

        public async Task<IEnumerable<Spell>> GetAllSpells()
        {
            return await _ctx.Spells!.Where(c => c.IsDeleted != true).ToListAsync();
        }

        public async Task<Spell?> GetSpellById(int id)
        {
            return await _ctx.Spells.FirstOrDefaultAsync(c => c.ID == id && c.IsDeleted != true);
        }

        public async Task SaveChanges()
        {
            await _ctx.SaveChangesAsync();
        }

    }
}
