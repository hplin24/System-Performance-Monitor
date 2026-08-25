using SystemPerformanceMonitor.Infrastructure.Metrics;

namespace SystemPerformanceMonitor.Tests
{
    public class WindowsMetricsCollectorTests
    {
        [Fact]
        public void GetCurrentMetrics_ReturnsMetrics()
        {
            var collector = new WindowsMetricsCollector();
            var metrics = collector.GetCurrentMetrics();

            Assert.InRange(metrics.CpuUsage, 0, 100);
            Assert.InRange(metrics.MemoryUsage, 0, 100);
        }
    }
}
