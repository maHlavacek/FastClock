using System;
using System.Windows.Threading;

namespace EventsDemo.FastClock
{
    public class FastClock
    {
        #region Fields

        public static FastClock _instance;
        private DispatcherTimer _dispatcherTimer;

        private event EventHandler<DateTime> OneMinuteIsOver;

        #endregion


        #region Properties

        public int Factor { get; set; }
        public static FastClock Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new FastClock();
                }
                return _instance;
            } 
        }
        public bool IsRunning { get; set; }
        public DateTime Time { get; set; }


        #endregion

        #region Constructor

        private FastClock()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Tick += Timer_Tick;
            _instance.OneMinuteIsOver += OnOneMinuteIsOver;
        }

        #endregion

        #region Methods

        public void OnOneMinuteIsOver(object sender, DateTime time)
        {
            while (IsRunning)
            {
                OneMinuteIsOver?.Invoke(this, time);
            }
        }

        private void Timer_Tick(object sender,EventArgs args)
        {
            _dispatcherTimer.Interval = new TimeSpan(0,0,Factor);
            _dispatcherTimer.Start();
        }
        #endregion
    }
}
