using HelpApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HelpApp.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
              new Category(1, "Material Escolar"),
              new Category(2, "Eletrônicos"),
              new Category(3, "Acessórios"),
              new Category(4, "Higiene Pessoal"),
              new Category(5, "Alimento Não Perecíveis"),
              new Category(6, "Brinquedos"),
              new Category(7, "Roupas"),
              new Category(8, "Móveis"),
              new Category(9, "Livros"),
              new Category(10, "Esporte e Lazer")
            );
        }
    }
}
