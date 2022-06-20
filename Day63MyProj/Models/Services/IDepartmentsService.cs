using Day63MyProj.Models.ViewModel;

namespace Day63MyProj.Models.Services
{
    public interface IDepartmentsService
    {
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task UpdateAsync(DepartmentViewModel departmentViewModel);
        Task DeleteAsync(int id);
        Task CreateAsync(DepartmentViewModel departmentViewModel);
    }
}
