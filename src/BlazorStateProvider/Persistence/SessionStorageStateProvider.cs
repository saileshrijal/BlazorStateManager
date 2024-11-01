using Blazored.SessionStorage;
using BlazorStateProvider.Interface;

namespace BlazorStateProvider.Persistence;

public class SessionStorageStateProvider(ISessionStorageService sessionStorageService) : ISessionStorageStateProvider
{
    private readonly List<Action> _subscribers = new();

    public async Task<T> GetStateAsync<T>(string key)
    {
        return await sessionStorageService.GetItemAsync<T>(key) ?? default!;
    }

    public async Task SetStateAsync<T>(string key, T value)
    {
        await sessionStorageService.SetItemAsync(key, value);
        await NotifyStateChangedAsync();
    }

    public async Task RemoveStateAsync(string key)
    {
        await sessionStorageService.RemoveItemAsync(key);
        await NotifyStateChangedAsync();
    }

    public async Task ResetStateAsync()
    {
        await sessionStorageService.ClearAsync();
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