using FluentResults;
using GenericEcommerce.Application.Dto.User;
using GenericEcommerce.Application.Interfaces;
using GenericEcommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GenericEcommerce.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<IdentityRole<int>> _roleManager;

        public UserApplicationService(
            UserManager<CustomIdentityUser> userManager, RoleManager<IdentityRole<int>> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<CustomIdentityUser>> GetAllAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 10;
            }

            return await _userManager.Users
            .Skip((pageNumber - 1) * pageSize) // Pula os registros das páginas anteriores
            .Take(pageSize) // Toma a quantidade de registros especificada
            .ToListAsync();
        }

        public async Task<CustomIdentityUser> GetByIdAsync(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IdentityResult> CreateUserAsync(CreateUserDto createDto)
        {
            CustomIdentityUser usuarioIdentity = new CustomIdentityUser()
            {
                UserName = createDto.Username,
                Email = createDto.Email,
                DataNascimento = createDto.DataNascimento,
            };

            var resultIdentity = await _userManager.CreateAsync(usuarioIdentity, createDto.Password);

            if (resultIdentity.Succeeded)
            {
                await _userManager.AddToRoleAsync(usuarioIdentity, "regular");
            }

            return resultIdentity;
            // if (resultIdentity.Succeeded)
            // {
            //     // var code = await _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity);

            //     //var encodedCode = HttpUtility.UrlEncode(code);
            //     // _emailService.EnviarEmail(new[] { usuarioIdentity.Email}, "Link de Ativação", usuarioIdentity.Id, encodedCode);
            //     return resultIdentity;
            // }
        }

        public async Task<Result> UpdateAsync(string id, UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return Result.Fail("User not found");
            }

            user.UserName = updateUserDto.Username;

            var resultIdentity = await _userManager.UpdateAsync(user);
            if (resultIdentity.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Failed to update user");
        }

        public async Task<Result> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return Result.Fail("User not found");
            }

            try
            {
                await _userManager.DeleteAsync(user);
                return Result.Ok();
            }catch(Exception e)
            {
                return Result.Fail("Failed to update user");
            }
        }
    }
}