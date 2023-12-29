using SimpleApiDI.Services.Interfaces;

namespace SimpleApiDI.Services;

public class SecondService
{
    private readonly ILogger<SecondService> _logger;
    private readonly IOperationTransient _transient;
    private readonly IOperationScoped _scoped;
    private readonly IOperationSingleton _singleton;

    public SecondService(ILogger<SecondService> logger, IOperationSingleton singleton, IOperationTransient transient, IOperationScoped scoped)
    {
        _logger = logger;
        _singleton = singleton;
        _transient = transient;
        _scoped = scoped;
    }

    public void GenerateResult()
    {
        _logger.LogInformation($" Second Service Transient: {_transient.OperationId}");
        _logger.LogInformation($" Second Service Scoped: {_scoped.OperationId}");
        _logger.LogInformation($" Second Service Singleton: {_singleton.OperationId}");
    }
}