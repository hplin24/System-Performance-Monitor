using System;
using System.Collections.Generic;
using System.Text;
using SystemPerformanceMonitor.Core.Interfaces;
using SystemPerformanceMonitor.Core.Models;

namespace SystemPerformanceMonitor.Core.Services
{
    public class MetricsService
    {
        private readonly IMetricsCollector _metricsCollector;

        public MetricsService(IMetricsCollector metricsCollector)
        {
            _metricsCollector = metricsCollector;
        }

        public PerformanceMetrics GetCurrentMetrics()
        {
            return _metricsCollector.GetCurrentMetrics();
        }
    }
}
