using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestApp1.Data;
using TestApp1.DTOs;
using TestApp1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();

sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQLDbConnection");

builder.Services.AddDbContext<ApplicationDBContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));
builder.Services.AddScoped<ISpellRepo, SpellRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/v1/spells", async (ISpellRepo repo, IMapper mapper) =>
{
    var spells = await repo.GetAllSpells();
    return Results.Ok(mapper.Map<IEnumerable<SpellReadDTO>>(spells));
});

app.MapGet("api/v1/spells/{id}", async (ISpellRepo repo, IMapper mapper, int id) =>
{
    var spell = await repo.GetSpellById(id);
    if (spell != null)
    {
        return Results.Ok(mapper.Map<SpellReadDTO>(spell));
    }
    return Results.NotFound();
});

app.MapPost("api/v1/spells", async (ISpellRepo repo, IMapper mapper, [FromBody]SpellCreateDTO spellCreateDTO) =>
{
    if (spellCreateDTO != null)
    {
        var spellModel = new Spell();
        spellModel.GUID = Guid.NewGuid();
        spellModel = mapper.Map<Spell>(spellCreateDTO);

        await repo.CreateSpell(spellModel);
        await repo.SaveChanges();

        var spellReadDTO = mapper.Map<SpellReadDTO>(spellModel);

        return Results.Created($"api/v1/spells",spellReadDTO);
    }
    return Results.Text("Spell DTO is NULL");
});

app.MapPut("api/v1/spells/{id}", async (ISpellRepo repo, IMapper mapper, [FromRoute]int id, [FromBody]SpellUpdateDTO spellUpdateDTO) =>
{
    if (spellUpdateDTO != null) 
    {
        var spellToUpdate = await repo.GetSpellById(id);
        if (spellToUpdate == null) 
        {
            return Results.NotFound();
        }

        mapper.Map(spellUpdateDTO, spellToUpdate);
        await repo.SaveChanges();

        return Results.Ok(mapper.Map<SpellReadDTO>(spellToUpdate));
    }
    return Results.Text("Spell Update DTO empty");
});

app.MapDelete("api/v1/spells/{id}", async (ISpellRepo repo, IMapper mapper, [FromRoute] int id) =>
{
    repo.DeleteSpell(id);
    await repo.SaveChanges();

    return Results.NoContent();
});

app.Run();