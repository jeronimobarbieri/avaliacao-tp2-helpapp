using HelpApp.Domain;
using HelpApp.Domain.Validation;
using HelpApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using System;
using System.Net;

namespace HelpApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Should create a valid product with name, description, price, stock and image")]
        public void CreateProduct_WithValidParameters_ShouldCreatObject()
        {

            Action action = () => new Product("Product Name", "Product Description", 99.90m, 10, "/img/productImage.jpg");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Should create a valid product with id and all fields")]
        public void CreateProduct_WithIdAndValidParameters_ShouldCreatObject()
        {

            Action action = () => new Product(1, "Product Name", "Product Description", 150.00m, 5, "/img/productImage.jpg");
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion


        #region Testes Negativos
        [Fact(DisplayName = "Should throw exception when product is created with negative id")]
        public void CreateProduct_WithNegativeId_ShouldThrowException()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 250.00m,
                15, "/img/productImage.jpg");

            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Update Invalid Id Value");
        }

        [Theory(DisplayName = "Should throw exception when product has null or empty name")]
        [InlineData(null)]
        [InlineData("")]
        public void CreateProduct_WhithNullOrEmptyName_ShouldThrowException(string? name)
        {

            Action action = () => new Product(name!, "Product Description", 250.00m, 15, "/img/productImage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name, name is required.");
        }


        [Fact(DisplayName = "Should throw exception when name has less than 3 characters")]
        public void CreateProduct_WithShortName_ShouldThrowException()
        {
            Action action = () => new Product("Pr", "Product Description", 250.00m, 15, "/img/productImage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Should throw exception when image is null")]
        public void CreateProduct_WithNullImageName_ShouldThrowException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image address, image is required.");
        }

        [Theory(DisplayName = "Should throw exception when product has null or empty name")]
        [InlineData(null)]
        [InlineData("")]
        public void CreateProduct_WithNullOrEmptyDescription_ShouldThrowException(string? description)
        {
            Action action = () => new Product("Product Name", description!, 250.00m, 15, "/img/productImage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid description, name is required.");
        }


        [Fact(DisplayName = "Should throw exception when description is too short")]
        public void CreateProduct_WithShortDescription_ShouldThrowException()
        {
            Action action = () => new Product("Product Name", "Prod", 250.00m, 15, "/img/productImage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = "Should throw exception when price is negative")]
        public void CreateProduct_WithNegativePrice_ShouldThrowException()
        {
            Action action = () => new Product("Product Name", "Product Description", -250.00m, 15, "/img/productImage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid price negative value.");

        }

        [Fact(DisplayName = "Should throw exception when stock is negative")]
        public void CreateProduct_WithNegativeStock_ShouldThrowException()
        {
            Action action = () => new Product("Product Name", "Product Description", 250.00m, -2, "/img/productImage.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid stock negative value.");
        }

        [Theory(DisplayName = "Should throw exception when image is null or empty")]
        [InlineData(null)]
        [InlineData("")]
        public void CreateProduct_WithNullOrEmptyImage_ShouldThrowException(string? image)
        {
            Action action = () => new Product("Product Name", "Product Description", 250.00m, 15, image!);
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image address, image is required.");

        }


        [Fact(DisplayName = "Should throw exception when image length exceeds 250 characters")]
        public void CreateProduct_WithTooLongImageName_ShouldThrowException()
        {

            string longImageName = new string('p', 251);
            Action action = () => new Product("Product Name", "Product Description", 250.00m, 15, longImageName);
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                    .WithMessage("Invalid image name, too long, maximum 250 characters.");

        }
        #endregion
    }
}
