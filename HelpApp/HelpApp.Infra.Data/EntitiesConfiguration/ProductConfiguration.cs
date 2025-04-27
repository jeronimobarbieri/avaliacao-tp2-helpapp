using HelpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpApp.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.Property(p => p.Image).HasMaxLength(250).IsRequired();
            builder.Property(p => p.Stock).IsRequired();
            builder.HasOne(e => e.Category).WithMany(e => e.Products)
                .HasForeignKey(e => e.CategoryId);

            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Garrafa Termica",
                    Description = "Garrafa de Inox 500ml para manter bebidas quentes ou frias",
                    Price = 79.90m,
                    Stock = 60,
                    Image = "garrafa.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Teclado mecânico",
                    Description = "Teclado gamer RGB com switches azuis",
                    Price = 229.90m,
                    Stock = 45,
                    Image = "teclado.jpg",
                    CategoryId = 2
                },

                new Product
                {
                    Id = 3,
                    Name = "Relógio de pulso",
                    Description = "Relógio digital à prova d'água com cronômetro",
                    Price = 149.00m,
                    Stock = 30,
                    Image = "relogio.jpg",
                    CategoryId = 3
                }

                );
        }
                
    }
}

