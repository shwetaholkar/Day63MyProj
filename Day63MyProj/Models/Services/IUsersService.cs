using Day63MyProj.Models.ViewModel;

namespace Day63MyProj.Models.Services
{
    public interface IUsersService
    {
        Task<List<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetByIdAsync(int id);
        Task UpdateAsync(UserViewModel userViewModel);
        Task DeleteAsync(int id);
        Task CreateAsync(UserViewModel userViewModel);


    }
}
