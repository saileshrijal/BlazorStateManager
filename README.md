# BlazorStateProvider

BlazorStateProvider is a state management library for Blazor applications that simplifies the management of state using local and session storage. It provides a clean and easy-to-use API for managing application state across components, ensuring that state is persisted as needed.

## Features

- **State Persistence**: Supports both local and session storage for persisting application state, allowing you to maintain state across user sessions or just within a single session.

- **Simple API**: Provides a straightforward interface for managing state with methods to get, set, remove, and reset state, making it easy to use throughout your Blazor application.

- **State Change Notifications**: Implements a subscription mechanism that notifies components of state changes, enabling a reactive programming model for better UI updates.

- **Type Safety**: Utilizes generics to ensure type-safe state management, reducing the risk of runtime errors when retrieving and storing state values.


## Installation

You can install the BlazorStateProvider NuGet package using the .NET CLI:

```bash
dotnet add package BlazorStateProvider
```
Or by adding it via the NuGet Package Provider in Visual Studio / Rider.

## Getting Started

### 1. Register the Services

To use the BlazorStateProvider in your application, register the services in your Program.cs file:

```csharp
using BlazorStateProvider.Extensions;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        // Register BlazorStateProvider services
        builder.Services.AddBlazorStateProvider();

        await builder.Build().RunAsync();
    }
}
```

### 2. Inject and Use the State Provider
You can now inject the state Providers into your Blazor components.

```csharp
@page "/example"
@inject IStateProvider StateProvider

<h3>State Management Example</h3>

<button @onclick="SaveState">Save State</button>
<button @onclick="LoadState">Load State</button>

@code {
    private async Task SaveState()
    {
        await StateProvider.SetStateAsync("exampleKey", "Hello, World!");
    }

    private async Task LoadState()
    {
        var value = await StateProvider.GetStateAsync<string>("exampleKey");
        Console.WriteLine($"Loaded State: {value}");
    }
}
```

## API Reference

### Interfaces

- `IStateProvider`: The main interface for managing state in Blazor applications.
- `ILocalStorageStateProvider`: Interface for managing state using local storage.
- `ISessionStorageStateProvider`: Interface for managing state using session storage.

### Methods

- `SetStateAsync<T>(string key, T value)`: Sets the state value for the specified key.
- `GetStateAsync<T>(string key)`: Gets the state value for the specified key.
- `RemoveStateAsync(string key)`: Removes the state value for the specified key.
- `ResetStateAsync()`: Resets the state by removing all stored values.
- `Subscribe<T>(Action callback)`: Subscribes to state change notifications for the specified key.
- `Unsubscribe<T>(Action callback)`: Unsubscribes from state change notifications for the specified key.

## Example
Here’s a simple example of how to use the BlazorStateProvider in your components:

```csharp
@page "/example"
@inject ILocalStorageStateProvider LocalStorageProvider

<h3>Local Storage Example</h3>

<button @onclick="SaveToLocalStorage">Save to Local Storage</button>
<button @onclick="LoadFromLocalStorage">Load from Local Storage</button>

@code {
    private async Task SaveToLocalStorage()
    {
        await LocalStorageProvider.SetStateAsync("username", "JohnDoe");
    }

    private async Task LoadFromLocalStorage()
    {
        var username = await LocalStorageProvider.GetStateAsync<string>("username");
        Console.WriteLine($"Loaded Username: {username}");
    }
}
```

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please submit an issue or a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
