using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Models
{
	public class Pizza
	{
		public int Id { get; set; }
		public string? Nom { get; set; }
		public string? Description { get; set; }
	}

}