using HelpApp.Domain.Entities;
using FluentAssertions;
using HelpApp.Domain.Validation;
using Xunit;

namespace HelpApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Should create a valid category with id and name")]
        public void CreateCategory_WithValidParameters_ShouldCreateObject()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();

        }

        [Fact(DisplayName = "Should create a valid category with name only and default id")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos
        [Fact(DisplayName = "Should throw exception when creating category with negative id")]
        public void CreateCategory_WithNegativeId_ShouldThrowException()
        {
            Action action = () => new Category(-1, "Category Name");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");

        }

        [Theory(DisplayName = "Should throw exception when creating category with null or empty name")]
        [InlineData(null)]
        [InlineData("")]
        public void CreateCategory_WithNullOrEmptyName_ShouldThrowException(string? name)
        {

            Action action = () => new Category(name!);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required.");

        }

        [Theory(DisplayName = "Should throw exception when creating category with name shorter than 3 characters")]
        [InlineData("N")]
        [InlineData("AM")]
        public void CreateCategory_WithShortName_ShouldThrowException(string name)
        {
            Action action = () => new Category(name);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        #endregion

    }
}
