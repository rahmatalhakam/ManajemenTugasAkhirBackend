using HotChocolate.Execution;
using HotChocolate.Execution.Instrumentation;
using HotChocolate.Resolvers;

namespace ManajemenTugasAkhirGeologi.Service.ErrorFilters;

public class ErrorLoggingDiagnosticsEventListener : ExecutionDiagnosticEventListener
{
    private readonly ILogger<ErrorLoggingDiagnosticsEventListener> _log;

    public ErrorLoggingDiagnosticsEventListener(ILogger<ErrorLoggingDiagnosticsEventListener> log)
    {
        _log = log;
    }

    public override void ResolverError(IMiddlewareContext context, IError error)
    {
        _log.LogError(error.Exception, error.Message);
    }

    public override void TaskError(IExecutionTask task, IError error)
    {
        _log.LogError(error.Exception, error.Message);
    }

    public override void RequestError(IRequestContext context, Exception exception)
    {
        _log.LogError(exception, "RequestError");
    }
}