using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManager.Business.Abstraction.Interfaces.Mediator;
using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Business.Abstraction.Interfaces.Repositories.Base;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Business.Abstraction.Interfaces.UnitOfWork;
using TaskManager.Infrastructure.Mediator;
using TaskManager.Infrastructure.Persistance.Context;
using TaskManager.Infrastructure.Persistance.Repositories;
using TaskManager.Infrastructure.Persistance.Repositories.Base;
using TaskManager.Infrastructure.Persistance.UnitOfWork;
using TaskManager.Infrastructure.Services;
using FluentValidation;

namespace TaskManager.Infrastructure.DependencyInjection;

public static class InfrastructureDI
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("HRM");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        #region Repositories
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IAssignmentEmployeeRepository, AssignmentEmployeeRepository>();
        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<IAttachmentRepository, AttachmentRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IProjectEmployeeRepository, ProjectEmployeeRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IReadDbConnection, ReadDbConnection>();
        services.AddScoped<IWriteDbConnection, WriteDbConnection>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IPasswordResetTokenRepository, PasswordResetTokenRepository>();
        //services.AddScoped<IDispatcher, Dispatcher>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        #region Services
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IOTPService, OTPService>();
        services.AddScoped<IJWTService, JWTService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        #endregion

        var context = services.BuildServiceProvider().GetRequiredService<ApplicationDbContext>();
        var passwordHasher = services.BuildServiceProvider().GetRequiredService<IPasswordService>();

        var seeder = new InitialDataSeeder(context, passwordHasher);

        seeder.SeedDataAsync();

        return services;
    }

    public static IServiceCollection AddAssemblies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var handlerTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));

        foreach (var handlerType in handlerTypes)
            services.AddScoped(handlerType);

        return services;

        //var assembliesToScan = new[]
        //{
        //    Assembly.GetExecutingAssembly(),
        //};

        //foreach (var assembly in assembliesToScan)
        //{
        //    var handlerTypes = assembly.GetTypes()
        //        .Where(t => t.GetInterfaces()
        //            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));

        //    foreach (var handlerType in handlerTypes)
        //        services.AddScoped(handlerType);
        //}

        //services.AddScoped<IDispatcher, Dispatcher>();

        //return services;
    }

    //public static IServiceCollection AddMediatR( this IServiceCollection services, 
    //    IConfiguration configuration, 
    //    params Assembly[] assembliesToScan)
    //{
    //    if (!assembliesToScan.Any())
    //    {
    //        assembliesToScan = new[]
    //        {
    //        Assembly.GetExecutingAssembly(),
    //        };
    //    }

    //    var handlerTypes = assembliesToScan
    //        .SelectMany(assembly => assembly.GetTypes())
    //        .Where(t => t.GetInterfaces().Any(i =>
    //            i.IsGenericType &&
    //            (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) || i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>))))
    //        .ToList();

    //    foreach (var handlerType in handlerTypes)
    //    {
    //        var interfaceType = handlerType.GetInterfaces().First(i =>
    //            i.IsGenericType &&
    //            (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) || i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)));

    //        services.AddScoped(interfaceType, handlerType);
    //    }

    //    services.AddScoped<IDispatcher, Dispatcher>();

    //    return services;
    //}

    public static IServiceCollection AddMediatorHandlers(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assembliesToScan)
    {
        if (assembliesToScan == null || assembliesToScan.Length == 0)
        {   
            assembliesToScan = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName != null && assembly.FullName.StartsWith("TaskManager."))
                .ToArray();
        }

        var handlerAssemblies = assembliesToScan
            .Where(assembly => assembly.GetTypes().Any(t =>
                t.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) || i.GetGenericTypeDefinition() == typeof(IRequest<>)))))
            .ToList();

        foreach (var assembly in handlerAssemblies)
        {
            var handlerTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                .ToList();

            foreach (var handlerType in handlerTypes)
            {
                var interfaceType = handlerType.GetInterfaces().First(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

                services.AddScoped(interfaceType, handlerType);
            }
        }

        services.AddScoped<IDispatcher, Dispatcher>();

        return services;
    }

    public static IServiceCollection AddValidators(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assembliesToScan)
    {
        if (assembliesToScan == null || assembliesToScan.Length == 0)
        {
            assembliesToScan = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName != null && assembly.FullName.StartsWith("TaskManager."))
                .ToArray();
        }

        services.AddValidatorsFromAssemblies(assembliesToScan);

        return services;
    }
}