using IT_Community.Server.Infrastructure.Dtos.CategoryDTOs;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategories();
        Task BatchCreateCategories(List<string> tagNames);
        Task DeleteCategory(int id);
    }
}
