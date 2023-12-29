using SimpleApiDI.Services.Interfaces;

namespace SimpleApiDI.Services.Contracts;

public class Operation: IOperationSingleton, IOperationTransient, IOperationScoped
{
    public string OperationId { get; } = Guid.NewGuid().ToString()[^6..];
}