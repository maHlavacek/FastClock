using System;
using System.Windows.Threading;

namespace EventsDemo.FastClock
{
    public class FastClock
    {
        #region Fields

        private static FastClock _instance;
        private DispatcherTimer _dispatcherTimer;

        public event EventHandler<DateTime> OneMinuteIsOver;

        #endregion


        #region Properties

        public int Factor
        {
            set
            {
                if(value <= 60000 && value > 0)
                _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(60000 / value);
            }

        }
        public static FastClock Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FastClock();
                }
                return _instance;
            }
        }
        public bool IsRunning
        {
            get
            {
                return _dispatcherTimer.IsEnabled;
            }
            set
            {
                _dispatcherTimer.IsEnabled = value;
            }
        }
        public DateTime Time { get; set; }


        #endregion

        #region Constructor

        private FastClock()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += Timer_Tick;
        }

        #endregion
        
        #region Methods

        private void Timer_Tick(object sender,EventArgs args)
        {
            Time = Time.AddMinutes(1);
            OneMinuteIsOver?.Invoke(this, Time);
        }
        #endregion
    }
}
