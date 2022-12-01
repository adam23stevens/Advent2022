using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_Infrastructure.Data.Entities
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsShopFavourite { get; set; }
		public bool IsCustomerFavourite { get; set; }
		public string Colour { get; set; }
		public string ImageUrl { get; set; }
		[ForeignKey("CategoryId")]
		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}
}

