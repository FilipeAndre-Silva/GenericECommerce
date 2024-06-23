using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericEcommerce.Domain.Entities;

namespace GenericEcommerce.Application.Interfaces
{
    public interface ITokenService
    {
        Token CreateToken(CustomIdentityUser usuario, string role);
    }
}