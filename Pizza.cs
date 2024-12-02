using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Models
{
	public class Pizza
	{
		public int Id { get; set; }
		public string? Nom { get; set; }
		public string? Description { get; set; }
	}
	
	// Classe PizzaDb qui représente le contexte de base de données
	public class PizzaDb : DbContext
	{
		public PizzaDb(DbContextOptions<PizzaDb> options) : base(options) { }
		public DbSet<Pizza> Pizzas { get; set; } = null!;
	}
}