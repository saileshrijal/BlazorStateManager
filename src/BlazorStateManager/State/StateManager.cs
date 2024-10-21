namespace BlazorStateManager.State;

public class StateManager : IStateManager
{
    private readonly Dictionary<string, object> _state = new();
    public event Action OnChange;

    public T GetState<T>(string key)
    {
        _state.TryGetValue(key, out var value);
        return (T)value;
    }

    public void SetState<T>(string key, T value)
    {
        _state[key] = value;
        NotifyStateChanged();
    }

    public void RemoveState(string key)
    {
        _state.Remove(key);
        NotifyStateChanged();
    }

    public void ResetState()
    {
        _state.Clear();
        NotifyStateChanged();
    }
    
    private void NotifyStateChanged() => OnChange?.Invoke();
}