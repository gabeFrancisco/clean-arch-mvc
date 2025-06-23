using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }  
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id > 0, "Invalid Id value!");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Name must be greater than 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");
            DomainExceptionValidation.When(description.Length < 3, "Description must be greater than 3 characters");
            DomainExceptionValidation.When(price <= 0, "Price must be greater than 0");
            DomainExceptionValidation.When(stock <= 0, "Stock must be greater than 0");
            DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Image is required");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}