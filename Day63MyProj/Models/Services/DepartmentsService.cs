using AutoMapper;
using Day63MyProj.Data;
using Day63MyProj.Data.Models;
using Day63MyProj.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Day63MyProj.Models.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private readonly UserManagementContext _dbContext;
        private readonly IMapper _mapper;

        public DepartmentsService( UserManagementContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            
            var departments = await _dbContext.Departments.ToListAsync();

            var departmentsViewModel = departments
                .Select(d => _mapper.Map<DepartmentViewModel>(d))
                .ToList();

            return departmentsViewModel;
        }

        public async Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            
            var department = await _dbContext.Departments.SingleAsync(d => d.Id == id);

            var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);

            return departmentViewModel;
        }

        public async Task UpdateAsync(DepartmentViewModel departmentViewModel)
        {
            var departmentToUpdate = await _dbContext.Departments.SingleAsync(d => d.Id == departmentViewModel.Id);

            departmentToUpdate.Name = departmentViewModel.Name;
            departmentToUpdate.Description = departmentViewModel.Description;

            _dbContext.Departments.Update(departmentToUpdate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var departmentToDelete = await _dbContext.Departments.SingleAsync(d => d.Id == id);

            _dbContext.Departments.Remove(departmentToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAsync(DepartmentViewModel departmentViewModel)
        {
          
            var departmentToAdd = _mapper.Map<Department>(departmentViewModel);

            await _dbContext.Departments.AddAsync(departmentToAdd);
            await _dbContext.SaveChangesAsync();
        }

    }
}
