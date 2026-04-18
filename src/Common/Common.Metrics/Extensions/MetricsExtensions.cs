using Microsoft.AspNetCore.Builder;
using Prometheus;

namespace Common.Metrics.Extensions;

public static class MetricsExtension
{
    public static WebApplication UsePrometheusMetrics(this WebApplication app)
    {
        app.UseHttpMetrics();
        app.UseMetricServer();
        
        return app;
    }
}