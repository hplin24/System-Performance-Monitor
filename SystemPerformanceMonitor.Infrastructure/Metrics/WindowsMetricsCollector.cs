using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SystemPerformanceMonitor.Core.Interfaces;
using SystemPerformanceMonitor.Core.Models;

namespace SystemPerformanceMonitor.Infrastructure.Metrics
{
    public class WindowsMetricsCollector : IMetricsCollector
    {
        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _memoryCounter;

        public WindowsMetricsCollector()
        {
            _cpuCounter = new PerformanceCounter(
                "Processor",
                "% Processor Time",
                "_Total");

            _memoryCounter = new PerformanceCounter(
                "Memory",
                "% Committed Bytes In Use");

            _cpuCounter.NextValue();

        }

        public PerformanceMetrics GetCurrentMetrics()
        {
            return new PerformanceMetrics
            {
                CpuUsage = _cpuCounter.NextValue(),
                MemoryUsage = _memoryCounter.NextValue()
            };
        }

    }
}
