using PizzaStore.Models;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurer SQLite comme base de données
var connectionString = builder.Configuration.GetConnectionString("Pizzas") ?? "Data Source=Pizzas.db";
builder.Services.AddSqlite<PizzaDb>(connectionString);
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "API PizzaStore",
		Description = "Faire les pizzas que vous aimez",
		Version = "v1"
	});
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
});

app.MapGet("/", () => "Bonjour Sénégal!");

app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());

app.MapPost("/pizza", async (PizzaDb db, Pizza pizza) =>
{
	await db.Pizzas.AddAsync(pizza);
	await db.SaveChangesAsync();
	return Results.Created($"/pizza/{pizza.Id}", pizza);
});

app.MapGet("/pizza/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));

app.MapPut("/pizza/{id}", async (PizzaDb db, Pizza updatepizza, int id) =>
{
	var pizza = await db.Pizzas.FindAsync(id);
	if (pizza is null) return Results.NotFound();
	pizza.Nom = updatepizza.Nom;
	pizza.Description = updatepizza.Description;
	await db.SaveChangesAsync();
	return Results.NoContent();
});

app.MapDelete("/pizza/{id}", async (PizzaDb db, int id) =>
{
	var pizza = await db.Pizzas.FindAsync(id);
	if (pizza is null)
	{
		return Results.NotFound();
	}
	db.Pizzas.Remove(pizza);
	await db.SaveChangesAsync();
	return Results.Ok();
});

app.Run();