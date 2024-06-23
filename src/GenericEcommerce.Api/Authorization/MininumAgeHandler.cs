using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GenericEcommerce.Api.Authorization
{
    public class MininumAgeHandler : AuthorizationHandler<MininumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            MininumAgeRequirement requirement)
        {
            if(!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                return Task.CompletedTask;
            }

            DateTime dateOfBirth = Convert.ToDateTime(context.User.FindFirst(c =>
                c.Type == ClaimTypes.DateOfBirth
            ).Value);

            int ageObtained = DateTime.Today.Year - dateOfBirth.Year;

            if(dateOfBirth > DateTime.Today.AddYears(- ageObtained))
            {
                ageObtained --;
            }

            if(ageObtained >= requirement.MininumAge)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}