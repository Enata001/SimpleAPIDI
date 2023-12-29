using SimpleApiDI.Services.Interfaces;

namespace SimpleApiDI.Services;

public class FirstService
{
    private readonly ILogger<FirstService> _logger;
    private readonly IOperationTransient _transient;
    private readonly IOperationScoped _scoped;
    private readonly IOperationSingleton _singleton;

    public FirstService(ILogger<FirstService> logger, IOperationSingleton singleton, IOperationTransient transient, IOperationScoped scoped)
    {
        _logger = logger;
        _singleton = singleton;
        _transient = transient;
        _scoped = scoped;
    }

    public void GenerateResult()
    {
        _logger.LogInformation($" First Service Transient: {_transient.OperationId}");
        _logger.LogInformation($" First Service Scoped: {_scoped.OperationId}");
        _logger.LogInformation($" First Service Singleton: {_singleton.OperationId}");
    }
}