using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BlazorStateProvider.Interface;
using BlazorStateProvider.Persistence;
using BlazorStateProvider.State;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorStateProvider.Extensions;

public static class ServiceExtensions
{
    public static void AddBlazorStateManager(this IServiceCollection services)
    {
        services.AddBlazoredLocalStorage();
        services.AddBlazoredSessionStorage();
        services.AddScoped<IStateProvider, StateProvider>();
        services.AddScoped<ILocalStorageStateProvider, LocalStorageStateProvider>();
        services.AddScoped<ISessionStorageStateProvider, SessionStorageStateProvider>();
    }
}