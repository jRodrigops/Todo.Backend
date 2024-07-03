using Todo.Backend.Mapper;
using Todo.Backend.Repositories;
using Todo.Backend.Services;

namespace Todo.Backend.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection Ioc(this IServiceCollection services)
    {
        services.AddScoped<IToDoTaskRepository, ToDoTaskRepository>();
        services.AddScoped<IToDoTaskService, ToDoTaskService>();

        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }
}
