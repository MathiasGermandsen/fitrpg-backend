using fitrpg_backend.Data.Repositories;
using fitrpg_backend.Data.Repositories.Interfaces;
using fitrpg_backend.Services;
using fitrpg_backend.Services.Interfaces;

namespace fitrpg_backend.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    // Repositories
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IWorkoutRepository, WorkoutRepository>();

    // Services
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IWorkoutService, WorkoutService>();
    services.AddScoped<IGamificationService, GamificationService>();

    return services;
  }
}
