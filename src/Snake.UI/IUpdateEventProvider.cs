using System;
using System.Timers;

namespace Snake.UI
{
    public interface IUpdateEventProvider
    {
        event EventHandler<EventArgs> UpdateEvent;
    }
    
    public class UpdateEventTimerProvider : IUpdateEventProvider
    {
        private Timer _timer;
        public UpdateEventTimerProvider()
        {
            _timer = new Timer(){Enabled = true};
            _timer.Elapsed += OnUpdate;
        }
        
        public event EventHandler<EventArgs> UpdateEvent;

        private void OnUpdate(object sender, ElapsedEventArgs args)
        {
            UpdateEvent?.Invoke(sender, null);
        }
    }
}