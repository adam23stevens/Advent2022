using System;
using Blazor_Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Infrastructure
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}

