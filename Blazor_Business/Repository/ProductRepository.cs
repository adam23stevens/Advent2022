using System;
using AutoMapper;
using Blazor_Business.Repository.IRepository;
using Blazor_Infrastructure;
using Blazor_Infrastructure.Data.Entities;
using Blazor_Models;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            var addedProduct = await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(addedProduct.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var product = ReadFromDatabase(id);
            _db.Products.Remove(product);

            return await _db.SaveChangesAsync();
        }

        public async Task<ProductDTO> Get(int id)
        {
            var product = ReadFromDatabase(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products.Include(x => x.Category));
        }

        public async Task<ProductDTO> Update(ProductDTO productDTO)
        {
            var product = ReadFromDatabase(productDTO.Id);
            if (product.Id != productDTO.Id)
            {
                throw new Exception($"Invalid id {productDTO.Id} passed on Update");
            }
            product = _mapper.Map<ProductDTO, Product>(productDTO, product);
            _db.Products.Update(product);
            await _db.SaveChangesAsync();

            return _mapper.Map<Product, ProductDTO>(product);
        }

        private Product ReadFromDatabase(int productId)
        {
            var product = _db.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == productId);
            if (product == null)
            {
                throw new Exception($"Product with Id {productId} not found in db");
            }

            return product;
        }
    }
}

