using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BlazorStateManager.Interface;
using Microsoft.Extensions.DependencyInjection;
using BlazorStateManager.Persistence;

namespace BlazorStateManager.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddBlazorStateManager(this IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();
            services.AddSingleton<IStateProvider, State.BlazorStateManager>();
            services.AddSingleton<IStateProvider, LocalStorageStateProvider>();
            services.AddSingleton<IStateProvider, SessionStorageStateProvider>();
        }
    }
}