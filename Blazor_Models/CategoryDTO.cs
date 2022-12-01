using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor_Models
{
	public class CategoryDTO
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
	}
}

