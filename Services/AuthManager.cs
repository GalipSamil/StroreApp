using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using StoreApp.Entities.Models;
using StoreApp.Entities.Dtos;
using AutoMapper;

namespace Services
{   
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IMapper _mapper;

        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles =>
             _roleManager.Roles;

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }
        


        public async Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var result = await _userManager.CreateAsync(user,userDto.Password);

            if (!result.Succeeded)
                throw new Exception();
            if(userDto.Roles.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if(!roleResult.Succeeded)
                    throw new Exception("System have not ne created");
            }
            return result;
        }

        public Task<IdentityResult> DeleteOneUser(string userName)
        {
            throw new NotImplementedException();
        }

    
        

        public Task<IdentityUser> GetOneUser(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<UserDtoForUpdate> GetOneUserForUpdate(string userName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentityRole> GetRoles()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ResetPassword(ResetPasswordDto model)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserDtoForUpdate userDto)
        {
            throw new NotImplementedException();
        }

        Task<UserDtoForUpdate> IAuthService.GetOneUserForUpdate(string userName)
        {
            throw new NotImplementedException();
        }

      
        public Task Update(UserDtoForUpdate userDto)
        {
            throw new NotImplementedException();
        }
    }
}
