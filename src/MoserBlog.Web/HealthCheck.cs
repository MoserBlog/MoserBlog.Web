using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MoserBlog.Web;

public class HealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var isHealthy = true;

        return isHealthy
            ? Task.FromResult(HealthCheckResult.Healthy())
            : Task.FromResult(HealthCheckResult.Degraded());
    }
}
