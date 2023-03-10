using System.Collections;
using TestApp1.Models;

namespace TestApp1.Data
{
    public interface ISpellRepo
    {
        Task SaveChanges();
        Task<Spell?> GetSpellById(int id);
        Task<IEnumerable<Spell>> GetAllSpells();
        Task CreateSpell(Spell spell);
        void DeleteSpell(int id); 
    }
}
