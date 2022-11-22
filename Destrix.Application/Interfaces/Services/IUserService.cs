using Destrix.DTO.Request.User;
using Destrix.DTO.Response.User;

namespace Destrix.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponse> GetUserByEmail(string email);

        Task<List<UserCategoryResponse>> GetCategories();
        Task<List<UserCategoryResponse>> GetCategoriesResume();
        Task<UserCategoryResponse> GetCategory(int categoryId);
        Task<UserCategoryResponse> GetCategoryDetails(int categoryId);
        Task<UserCategoryResponse> CreateCategory(UserCategoryRequest userCategoryRequest);
        Task<UserCategoryResponse> UpdateCategory(UserCategoryRequest userCategoryRequest);
    }
}
