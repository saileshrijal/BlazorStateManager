# BlazorStateManager

BlazorStateManager is a state management library for Blazor applications that simplifies the management of state using local and session storage. It provides a clean and easy-to-use API for managing application state across components, ensuring that state is persisted as needed.

## Features

- **State Persistence**: Supports both local and session storage for persisting application state, allowing you to maintain state across user sessions or just within a single session.

- **Simple API**: Provides a straightforward interface for managing state with methods to get, set, remove, and reset state, making it easy to use throughout your Blazor application.

- **State Change Notifications**: Implements a subscription mechanism that notifies components of state changes, enabling a reactive programming model for better UI updates.

- **Type Safety**: Utilizes generics to ensure type-safe state management, reducing the risk of runtime errors when retrieving and storing state values.


## Installation

You can install the BlazorStateManager NuGet package using the .NET CLI:

```bash
dotnet add package BlazorStateManager
```
Or by adding it via the NuGet Package Manager in Visual Studio / Rider.

## Getting Started

### 1. Register the Services

To use the BlazorStateManager in your application, register the services in your Program.cs file:

```csharp
using BlazorStateManager.Extensions;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        // Register BlazorStateManager services
        builder.Services.AddBlazorStateManager();

        await builder.Build().RunAsync();
    }
}
```

### 2. Inject and Use the State Manager
You can now inject the state managers into your Blazor components.

```csharp
@page "/example"
@inject IStateManager StateManager

<h3>State Management Example</h3>

<button @onclick="SaveState">Save State</button>
<button @onclick="LoadState">Load State</button>

@code {
    private async Task SaveState()
    {
        await StateManager.SetStateAsync("exampleKey", "Hello, World!");
    }

    private async Task LoadState()
    {
        var value = await StateManager.GetStateAsync<string>("exampleKey");
        Console.WriteLine($"Loaded State: {value}");
    }
}
```

## API Reference

### Interfaces

- `IStateManager`: The main interface for managing state in Blazor applications.
- `ILocalStorageStateManager`: Interface for managing state using local storage.
- `ISessionStorageStateManager`: Interface for managing state using session storage.

### Methods

- `SetStateAsync<T>(string key, T value)`: Sets the state value for the specified key.
- `GetStateAsync<T>(string key)`: Gets the state value for the specified key.
- `RemoveStateAsync(string key)`: Removes the state value for the specified key.
- `ResetStateAsync()`: Resets the state by removing all stored values.
- `Subscribe<T>(Action callback)`: Subscribes to state change notifications for the specified key.
- `Unsubscribe<T>(Action callback)`: Unsubscribes from state change notifications for the specified key.

## Example
Here’s a simple example of how to use the BlazorStateManager in your components:

```csharp
@page "/example"
@inject ILocalStorageStateManager LocalStorageManager

<h3>Local Storage Example</h3>

<button @onclick="SaveToLocalStorage">Save to Local Storage</button>
<button @onclick="LoadFromLocalStorage">Load from Local Storage</button>

@code {
    private async Task SaveToLocalStorage()
    {
        await LocalStorageManager.SetStateAsync("username", "JohnDoe");
    }

    private async Task LoadFromLocalStorage()
    {
        var username = await LocalStorageManager.GetStateAsync<string>("username");
        Console.WriteLine($"Loaded Username: {username}");
    }
}
```

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please submit an issue or a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
