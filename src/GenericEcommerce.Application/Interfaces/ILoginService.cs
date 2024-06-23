using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using GenericEcommerce.Application.Dto.Login;

namespace GenericEcommerce.Application.Interfaces
{
    public interface ILoginService
    {
        Result UserLoginAsync(LoginRequest request);
    }
}