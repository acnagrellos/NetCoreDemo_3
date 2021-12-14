namespace MyProject.Host.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public Product(int productId, string name, int category)
        {
            this.Id = productId;
            this.Name = name;
            this.CategoryId = category;
        }
    }
}
