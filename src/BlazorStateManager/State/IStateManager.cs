namespace BlazorStateManager.State;

public interface IStateManager
{
    T GetState<T>(string key);
    void SetState<T>(string key, T value);
    void RemoveState(string key);
    void ResetState();
}