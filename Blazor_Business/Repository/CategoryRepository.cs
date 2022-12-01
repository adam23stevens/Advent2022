using System;
using AutoMapper;
using Blazor_Business.Repository.IRepository;
using Blazor_Infrastructure;
using Blazor_Infrastructure.Data.Entities;
using Blazor_Models;

namespace Blazor_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _db = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            var addedCategory = await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();

            return _mapper.Map<CategoryDTO>(addedCategory.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var category = ReadFromDatabase(id);
            _db.Categories.Remove(category);

            return await _db.SaveChangesAsync();
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var category = ReadFromDatabase(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDTO)
        {
            var category = ReadFromDatabase(categoryDTO.Id);
            if (category.Id != categoryDTO.Id)
            {
                throw new Exception($"Invalid id {categoryDTO.Id} passed on Update");
            }
            category.Name = categoryDTO.Name;
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();

            return _mapper.Map<Category, CategoryDTO>(category);
        }

        private Category ReadFromDatabase(int categoryId)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == categoryId);
            if (category == null)
            {
                throw new Exception($"Category with Id {categoryId} not found in db");
            }

            return category;
        }
    }
}

