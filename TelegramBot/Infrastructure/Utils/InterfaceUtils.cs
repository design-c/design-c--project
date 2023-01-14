namespace Infrastructure.Utils;

public static class InterfaceUtils
{
    public static IEnumerable<T> GetImplementedClasses<T>()
        where T : class
    {
        if (!typeof(T).IsInterface)
            throw new ArgumentException($"Type must be an interface: {typeof(T)}");
        
        var allCommands = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(type => typeof(T).IsAssignableFrom(type) && type is { IsInterface: false, IsAbstract: false })
            .Select(type => (T)Activator.CreateInstance(type)!);

        return allCommands;
    }
}