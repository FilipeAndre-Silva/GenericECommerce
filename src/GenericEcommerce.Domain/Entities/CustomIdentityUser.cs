using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GenericEcommerce.Domain.Entities
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}