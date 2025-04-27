using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace HelpApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Atributos
        private readonly ApplicationDbContext _dbContext;
        private Product product;

        #endregion

        #region Construtor
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Métodos
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _dbContext.Products.Include(product => product.Category).AsNoTracking().ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int? id)
        {
            ValidateId(id);
            var products = await _dbContext.Products.Include(product => product.Category).AsNoTracking().FirstOrDefaultAsync(product => product.Id == id);
            return product;
        }

        public async Task<Product> Create(Product product)
        {
            ValidateProduct(product);
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        private void ValidateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Update(Product product)
        {
            ValidateCategory(product);
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            ValidateCategory(product);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }
        #endregion

        #region Validação

        private void ValidateCategory(Product? product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product must be provided.");
        }

        private void ValidateId(int? id)
        {
            if (!id.HasValue || id <= 0)
                throw new ArgumentException("Category ID must be a positive number.", nameof(id));
        }
        #endregion  
    }
}
