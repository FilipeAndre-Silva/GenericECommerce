using Microsoft.Extensions.DependencyInjection;
using GenericEcommerce.Infra;
using GenericEcommerce.Domain;
using GenericEcommerce.Application.Interfaces;
using GenericEcommerce.Application.Services;
using GenericEcommerce.Application.Dto.User;
using FluentValidation.AspNetCore;
using GenericEcommerce.Application.Dto.Login;

namespace GenericEcommerce.Application;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddInfraDependency();
        services.AddDomainServiceDependency();

        services.AddScoped<IProductApplicationService, ProductApplicationService>();
        services.AddScoped<IUserApplicationService, UserApplicationService>();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserDtoValidator>());
        services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateUserDto>());
        services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequest>());
    }
}