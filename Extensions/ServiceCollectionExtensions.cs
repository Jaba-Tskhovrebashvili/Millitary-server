using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.Helpers.Implementations;
using MillitaryService.Helpers.Interfaces;
using MillitaryService.Repositories;
using MillitaryService.Repositories.Implementations;
using MillitaryService.Repositories.Interfaces;
using MillitaryService.Services.Implementations;
using MillitaryService.Services.Interfaces;

namespace MillitaryService.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IPersonnelRepository, PersonnelRepository>();
        services.AddScoped<IRankRepository, RankRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IMilitaryUnitsRepository, MilitaryUnitsRepository>();
        services.AddScoped<IPersonnelAssignmentsRepository, PersonnelAssignmentsRepository>();
        services.AddScoped<IPositionsRepository, PositionsRepository>();
        services.AddScoped<IPersonnelCoursesRepository, PersonnelCoursesRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IPersonnelService, PersonnelService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IRankService, RankService>();
        services.AddScoped<IMilitaryUnitsService, MilitaryUnitsService>();
        services.AddScoped<IPersonnelAssignmentsService, PersonnelAssignmentsService>();
        services.AddScoped<IPositionsService, PositionsService>();
        services.AddScoped<IPersonnelCoursesService, PersonnelCoursesService>();
        services.AddScoped<IAuthHelper, AuthHelper>();
        services.AddScoped<IPersonnelHelper, PersonnelHelper>();

        return services;
    }
}