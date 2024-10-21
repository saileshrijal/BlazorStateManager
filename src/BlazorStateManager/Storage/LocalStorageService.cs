using Blazored.LocalStorage;

namespace BlazorStateManager.Storage;

public class LocalStorageService(ILocalStorageService localStorageService)
{
    public async Task SetItemAsync(string key, string value)
    {
        await localStorageService.SetItemAsync(key, value);
    }

    public async Task<string> GetItemAsync(string key)
    {
        return await localStorageService.GetItemAsync<string>(key);
    }

    public async Task RemoveItemAsync(string key)
    {
        await localStorageService.RemoveItemAsync(key);
    }
}