using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor_Models
{
	public class ProductDTO
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		public bool IsShopFavourite { get; set; }
		public bool IsCustomerFavourite { get; set; }
		public string Colour { get; set; }
		public string ImageUrl { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = "Please select a valid Category")]
		public int CategoryId { get; set; }
		public CategoryDTO Category { get; set; }
	}
}

