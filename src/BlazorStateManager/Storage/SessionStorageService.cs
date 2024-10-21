using Blazored.SessionStorage;

namespace BlazorStateManager.Storage;

public class SessionStorageService(ISessionStorageService sessionStorageService)
{
    public async Task SetItemAsync(string key, string value)
    {
        await sessionStorageService.SetItemAsync(key, value);
    }

    public async Task<string> GetItemAsync(string key)
    {
        return await sessionStorageService.GetItemAsync<string>(key);
    }

    public async Task RemoveItemAsync(string key)
    {
        await sessionStorageService.RemoveItemAsync(key);
    }
}