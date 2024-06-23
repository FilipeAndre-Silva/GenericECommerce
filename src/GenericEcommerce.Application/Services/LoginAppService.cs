using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using GenericEcommerce.Application.Dto.Login;
using GenericEcommerce.Application.Interfaces;
using GenericEcommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GenericEcommerce.Application.Services
{
    public class LoginService : ILoginService
    {
        private SignInManager<CustomIdentityUser> _signInManager;
        private readonly ITokenService _tokenService;
        public LoginService(SignInManager<CustomIdentityUser> signInManager, ITokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result UserLoginAsync(LoginRequest request)
        {
            var userFound = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            if(userFound.Result.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users
                                    .FirstOrDefault(usuario => usuario.NormalizedUserName == request.Username.ToUpper());

                Token token = _tokenService.CreateToken(identityUser, _signInManager.UserManager.GetRolesAsync(
                    identityUser).Result.FirstOrDefault());

                return Result.Ok().WithSuccess(token.Value);
            } 

            return Result.Fail("Login falhou");
        }
    }
}