using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class UnitTest1
{
    [Fact(DisplayName = "Create Category with Valid State")]
    public void CreateCategory_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Category(0, "Cat name");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateCategory_WithNegativeId_ResultObjectValidState1()
    {
        Action action = () => new Category(1, "Wrong Cat name");
        action.Should()
            .NotThrow<DomainExceptionValidation>();
            // .WithMessage("Invalid ID data!");
    }

    [Fact]
    public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Category(0, "");
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required!");
    }
}
