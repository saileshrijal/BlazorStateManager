using BlazorStateProvider.Interface;

namespace BlazorStateProvider.State;

public class StateProvider : IStateProvider
{
    private readonly Dictionary<string, object> _state = new();
    private readonly List<Action> _subscribers = [];

    public Task<T> GetStateAsync<T>(string key)
    {
        _state.TryGetValue(key, out var value);
        return Task.FromResult((T)value!);
    }

    public Task SetStateAsync<T>(string key, T value)
    {
        _state[key] = value;
        return NotifyStateChangedAsync();
    }

    public Task RemoveStateAsync(string key)
    {
        if (_state.ContainsKey(key))
        {
            _state.Remove(key);
            return NotifyStateChangedAsync();
        }

        return Task.CompletedTask;
    }

    public Task ResetStateAsync()
    {
        _state.Clear();
        return NotifyStateChangedAsync();
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