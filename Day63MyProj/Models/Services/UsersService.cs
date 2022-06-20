using AutoMapper;
using Day63MyProj.Data;
using Day63MyProj.Data.Models;
using Day63MyProj.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Day63MyProj.Models.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManagementContext _dbContext;
        private readonly IMapper _mapper;

        public UsersService(UserManagementContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(UserViewModel userViewModel)
        {
            var userToAdd = _mapper.Map<User>(userViewModel);
           
            await _dbContext.Users.AddAsync(userToAdd);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var userToDelete = await _dbContext.Users.SingleAsync(u => u.Id == id);

            _dbContext.Users.Remove(userToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var users = await _dbContext.Users.Include("DepartmentRef").ToListAsync();
           
            var usersViewModel = users
                .Select(u => _mapper.Map<UserViewModel>(u))
                .ToList();

            return usersViewModel;

        }

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            var users = await _dbContext.Users.SingleAsync(u => u.Id == id);
            
            var userViewModel = _mapper.Map<UserViewModel>(users);

            return userViewModel;

        }

        public async Task UpdateAsync(UserViewModel userViewModel)
        {
            var userToUpdate = await _dbContext.Users.SingleAsync(u => u.Id == userViewModel.Id);

            userToUpdate.FirstName = userViewModel.FirstName;
            userToUpdate.LastName = userViewModel.LastName;
            userToUpdate.DateOfBirth = userViewModel.DateOfBirth;
            userToUpdate.Gender = userViewModel.Gender;
            userToUpdate.Email = userViewModel.Email;
            userToUpdate.MobileNumber = userViewModel.MobileNumber;
            userToUpdate.DepartmentRefId = userViewModel.DepartmentRefId;

            _dbContext.Users.Update(userToUpdate);
            await _dbContext.SaveChangesAsync();

        }
    }
}
