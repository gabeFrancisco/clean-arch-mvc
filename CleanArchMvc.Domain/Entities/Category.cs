using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required!");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name! Too short. Minimum 3 characters!");

            Name = name;
        }
    }
}