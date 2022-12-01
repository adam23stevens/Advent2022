using System;
using Blazor_Models;

namespace Blazor_Business.Repository.IRepository
{
	public interface IProductRepository
	{
        public Task<ProductDTO> Create(ProductDTO productDTO);
        public Task<ProductDTO> Update(ProductDTO productDTO);
        public Task<int> Delete(int id);
        public Task<ProductDTO> Get(int id);
        public Task<IEnumerable<ProductDTO>> GetAll();
    }
}

