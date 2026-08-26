using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using SystemPerformanceMonitor.Core.Services;

namespace SystemPerformanceMonitor.App.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly MetricsService _metricsService;

        [ObservableProperty]
        private double _cpuUsage;
        [ObservableProperty]
        private double _memoryUsage;
        [ObservableProperty]
        private bool _isMonitoring;

        [ObservableProperty]
        private string _status = "Ready";

        private CancellationTokenSource _monitoringCts;

        public MainViewModel(MetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        [RelayCommand]
        private async Task StartMonitoring()
        {
            if (IsMonitoring)
                return;

            IsMonitoring = true;
            Status = "Activated";
            _monitoringCts = new CancellationTokenSource();
            
            try
            {
                using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

                while (await timer.WaitForNextTickAsync(_monitoringCts.Token))
                {
                    var metrics = _metricsService.GetCurrentMetrics();

                    CpuUsage = metrics.CpuUsage;
                    MemoryUsage = metrics.MemoryUsage;
                }
            }
            catch (OperationCanceledException)
            {

            }
        }

        [RelayCommand]
        private void StopMonitoring()
        {
            _monitoringCts?.Cancel();
            _monitoringCts?.Dispose();
            _monitoringCts = null;

            IsMonitoring = false;
            Status = "Deactivated";
        }
    }
}
