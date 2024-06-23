using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GenericEcommerce.Api.Authorization
{
    public class MininumAgeRequirement : IAuthorizationRequirement
    {
        public int MininumAge { get; set; }
        public MininumAgeRequirement(int mininumAge)
        {
            MininumAge = mininumAge;
        }
    }
}