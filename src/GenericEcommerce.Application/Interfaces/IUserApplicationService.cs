using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using GenericEcommerce.Application.Dto.User;
using GenericEcommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GenericEcommerce.Application.Interfaces
{
    public interface IUserApplicationService
    {
        Task<CustomIdentityUser> GetByIdAsync(int id);
        Task<List<CustomIdentityUser>> GetAllAsync(int pageNumber, int pageSize);
        Task<IdentityResult> CreateUserAsync(CreateUserDto createDto);
        Task<Result> UpdateAsync(string id, UpdateUserDto updateUserDto);
        Task<Result> DeleteAsync(string id);
    }
}