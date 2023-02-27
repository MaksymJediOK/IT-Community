using AutoMapper;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Infrastructure.Dtos.CategoryDTOs;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Interfaces;
using System.Net;

namespace IT_Community.Server.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<CategoryDto> GetCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(categories);
            return categoryDtos;
        }

        public async Task BatchCreateCategories(List<string> categoryNames)
        {
            var categoryDtos = categoryNames.Select(x => new CategoryDto { Name = x.Trim() }).ToList();
            var existingCategories = GetCategories();
            var categoriesToCreate = categoryDtos.Where(t => !existingCategories.Any(et => et.Name == t.Name)).ToList();
            if (categoriesToCreate.Count > 0)
            {
                var categories = _mapper.Map<List<Category>>(categoriesToCreate);
                foreach (var category in categories)
                {
                    _unitOfWork.CategoryRepository.Insert(category);
                }
                await _unitOfWork.SaveAsync();
            }
            else
            {
                throw new HttpException("All of the categories already exist in the database", HttpStatusCode.BadRequest);
            }
        }

        public async Task DeleteCategory(int categoryId)
        {
            if (IsExist(categoryId))
            {
                _unitOfWork.CategoryRepository.Delete(categoryId);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                throw new HttpException("Category not found", HttpStatusCode.NotFound);
            }
        }

        public bool IsExist(int id)
        {
            if (id <= 0) return false;

            var category = _unitOfWork.CategoryRepository.GetById(id);

            if (category == null) return false;
            return true;
        }
    }
}
