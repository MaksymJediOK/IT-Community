using IT_Community.Server.Infrastructure.Dtos.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategories();
        Task BatchCreateCategories(List<string> tagNames);
        Task DeleteCategory(int id);
    }
}
