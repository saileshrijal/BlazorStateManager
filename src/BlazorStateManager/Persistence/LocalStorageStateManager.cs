using Blazored.LocalStorage;
using BlazorStateManager.Interface;

namespace BlazorStateManager.Persistence
{
    public class LocalStorageStateManager(ILocalStorageService localStorageService) : ILocalStorageStateManager
    {
        private readonly List<Action> _subscribers = new();

        public async Task<T> GetStateAsync<T>(string key)
        {
            return await localStorageService.GetItemAsync<T>(key) ?? default!;
        }

        public async Task SetStateAsync<T>(string key, T value)
        {
            await localStorageService.SetItemAsync(key, value);
            await NotifyStateChangedAsync();
        }

        public async Task RemoveStateAsync(string key)
        {
            await localStorageService.RemoveItemAsync(key);
            await NotifyStateChangedAsync();
        }

        public async Task ResetStateAsync()
        {
            await localStorageService.ClearAsync();
            await NotifyStateChangedAsync();
        }

        public Task SubscribeAsync(Action callback)
        {
            _subscribers.Add(callback);
            return Task.CompletedTask;
        }

        public Task UnsubscribeAsync(Action callback)
        {
            _subscribers.Remove(callback);
            return Task.CompletedTask;
        }

        private Task NotifyStateChangedAsync()
        {
            foreach (var subscriber in _subscribers)
                subscriber.Invoke();
            return Task.CompletedTask;
        }
    }
}