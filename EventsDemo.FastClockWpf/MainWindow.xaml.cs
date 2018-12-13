using System;
using System.Windows;

namespace EventsDemo.FastClockWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            DatePickerDate.SelectedDate = DateTime.Today;
            TextBoxTime.Text = DateTime.Now.ToShortTimeString();
        }

        private void ButtonSetTime_Click(object sender, RoutedEventArgs e)
        {
            TextBlockDate.Text = DatePickerDate.Text;
            TextBlockTime.Text = TextBoxTime.Text;
        }

        private void SetFastClockStartDateAndTime()
        {
            FastClock.FastClock.Instance.Time = DateTime.Parse(TextBlockDate.Text +" "+ TextBlockTime);
        }

        private void FastClockOneMinuteIsOver(object sender, DateTime fastClockTime)
        {
           
        }

        private void CheckBoxClockRuns_Click(object sender, RoutedEventArgs e)
        {
            if(CheckBoxClockRuns.IsChecked.Value)
            {
                FastClock.FastClock.Instance.IsRunning = true;

                if (int.TryParse(TextBoxFactor.Text, out int factor))
                {
                    FastClock.FastClock.Instance.Factor = factor;
                }
                else
                {
                    TextBoxFactor.Text = FastClock.FastClock.Instance.Factor.ToString();
                }              
            }
            FastClock.FastClock.Instance.IsRunning = false;
        }

        private void ButtonCreateView_Click(object sender, RoutedEventArgs e)
        {
            DigitalClock digitalClock = new DigitalClock();
            digitalClock.Owner = this;
            digitalClock.Show();
        }
    }
}
