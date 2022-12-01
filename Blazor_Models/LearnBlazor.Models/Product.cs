namespace Blazor_Models.LearnBlazor.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public bool IsActive { get; set; }
        public string Description
        {
            get
            {
                return $"{Name} | £{Price} | " + (IsActive ? "Active" : "Inactive");
            }
        }
        public List<ProductProperty> ProductProperties { get; set; }
    }
}

