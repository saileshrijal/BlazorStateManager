using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BlazorStateManager.State;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorStateManager.Utils;

public static class ServiceExtensions
{
    public static IServiceCollection AddBlazorStateManager(this IServiceCollection services)
    {
        services.AddBlazoredLocalStorage();
        services.AddBlazoredSessionStorage();
        services.AddSingleton<IStateManager, StateManager>();
        services.AddBlazoredLocalStorage();
        services.AddBlazoredSessionStorage();
        return services;
    }
}