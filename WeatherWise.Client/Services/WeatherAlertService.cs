
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MudBlazor;

    namespace WeatherWise.Client.Services
    {
        public class WeatherAlert
        {
            public string Message { get; set; }
            public Severity Severity { get; set; }
            public DateTime Timestamp { get; set; }
        }

        public class WeatherAlertService
        {
            private readonly List<WeatherAlert> _alerts = new List<WeatherAlert>();
            public event Func<Task> OnAlertsChanged;

            public IReadOnlyList<WeatherAlert> Alerts => _alerts.AsReadOnly();

            public void AddAlert(string message, Severity severity)
            {
                _alerts.Add(new WeatherAlert
                {
                    Message = message,
                    Severity = severity,
                    Timestamp = DateTime.Now
                });
                OnAlertsChanged?.Invoke();
            }

            public void ClearAlerts()
            {
                _alerts.Clear();
                OnAlertsChanged?.Invoke();
            }

            public void RemoveAlert(WeatherAlert alert)
            {
                _alerts.Remove(alert);
                OnAlertsChanged?.Invoke();
            }
        }
    }
