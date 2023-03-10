using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using TestApp1.Data;
using TestApp1.Models;
using TestApp1.DTOs;

using Microsoft.AspNetCore.JsonPatch;

namespace TestApp1.Controllers
{
    [ServiceFilter(typeof(TestAsyncActionFilter))]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SpellsController : ControllerBase
    {
        private readonly ISpellRepo _repo;
        private readonly IMapper _mapper;

        public SpellsController(ISpellRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpellReadDTO>>> GetAllSpells([FromHeader] bool flipSwitch)
        {
            var spells = await _repo.GetAllSpells();
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine($"--> The flip switch is: {flipSwitch}");
            Console.ResetColor();

            return Ok(_mapper.Map<IEnumerable<SpellReadDTO>>(spells));
        }

        [HttpGet("{id}", Name = "GetSpellById")]
        public async Task<ActionResult<SpellReadDTO>> GetSpellById(int id)
        {
            var spellModel = await _repo.GetSpellById(id);
            if (spellModel != null)
            {
                return Ok(_mapper.Map<SpellReadDTO>(spellModel));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<SpellReadDTO>> CreateCommand(SpellCreateDTO spellCreateDto)
        {
            var spellModel = _mapper.Map<Spell>(spellCreateDto);
            await _repo.CreateSpell(spellModel);
            await _repo.SaveChanges();

            var spellReadDto = _mapper.Map<SpellReadDTO>(spellModel);

            Console.WriteLine($"Model State is: {ModelState.IsValid}");

            return CreatedAtRoute(nameof(GetSpellById), spellReadDto);
        }

        //PATCH api/v1/spells/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialCommandUpdate(int id, JsonPatchDocument<SpellUpdateDTO> patchDoc)
        {
            var spellModelFromRepo = await _repo.GetSpellById(id);
            if (spellModelFromRepo == null)
            {
                return NotFound();
            }

            var spellToPatch = _mapper.Map<SpellUpdateDTO>(spellModelFromRepo);
            patchDoc.ApplyTo(spellToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

            if (!TryValidateModel(spellToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(spellToPatch, spellModelFromRepo);

            await _repo.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand(int id, SpellUpdateDTO spellUpdateDto)
        {
            var spellModelFromRepo = await _repo.GetSpellById(id);
            if (spellModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(spellUpdateDto, spellModelFromRepo);

            await _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSpell(int id)
        {
            var spellModelFromRepo = await _repo.GetSpellById(id);
            if (spellModelFromRepo == null)
            {
                return NotFound();
            }
            _repo.DeleteSpell(id);
            await _repo.SaveChanges();

            return NoContent();
        }
    }

}