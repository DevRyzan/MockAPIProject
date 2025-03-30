using Application.Services.MockAPIModelService;
using Core.Application.Pipelines.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Application.Features.MockAPIModels.Rules;

namespace Application.DIs;
/// <summary>
/// All classes derived from the Application Layer are implemented as class
/// </summary>
public static class ApplicationServiceDI
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
         
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        services.AddScoped<IObjectService, ObjectManager>();

        //Business Rules
        services.AddScoped<ObjectBusinessRules>();

        return services;

    }
}
