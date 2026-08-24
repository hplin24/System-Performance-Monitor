using System;
using System.Collections.Generic;
using System.Text;
using SystemPerformanceMonitor.Core.Models;

namespace SystemPerformanceMonitor.Core.Interfaces
{
    internal interface IMetricsCollector
    {
        PerformanceMetrics GetCurrentMetrics();
    }
}
