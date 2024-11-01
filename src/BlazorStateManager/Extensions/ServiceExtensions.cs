using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BlazorStateManager.Interface;
using Microsoft.Extensions.DependencyInjection;
using BlazorStateManager.Persistence;
using BlazorStateManager.State;

namespace BlazorStateManager.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddBlazorStateManager(this IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();
            services.AddScoped<IStateManager, StateManager>();
            services.AddScoped<ILocalStorageStateManager, LocalStorageStateManager>();
            services.AddScoped<ISessionStorageStateManager, SessionStorageStateManager>();
        }
    }
}