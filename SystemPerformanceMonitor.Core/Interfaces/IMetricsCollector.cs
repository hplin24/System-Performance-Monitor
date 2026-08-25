using System;
using System.Collections.Generic;
using System.Text;
using SystemPerformanceMonitor.Core.Models;

namespace SystemPerformanceMonitor.Core.Interfaces
{
    public interface IMetricsCollector
    {
        PerformanceMetrics GetCurrentMetrics();
    }
}
