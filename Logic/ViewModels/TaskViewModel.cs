using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Logic.Commands;
using Logic.Models;

namespace Logic.ViewModels
{
    public class TaskViewModel : IDisposable
    {
        private const int Minute = 60000;

        //private readonly int _waitMsec = Minute;//debug, 1 min
        private readonly int _exitWait = Minute / 6; //10 sec
        private readonly Settings _model;
        private readonly int _waitMsec = 5 * 1000 * 60; //5 min
        private CancellationTokenSource _token;

        public TaskViewModel(Settings model)
        {
            _model = model;
            StartTaskCommand = new RelayCommand<TaskViewModel>(StartCheckTask);
            StopTaskCommand = new RelayCommand<TaskViewModel>(StopCheckTask);
        }

        public ICommand StartTaskCommand { get; set; }
        public ICommand StopTaskCommand { get; set; }

        public Func<DateTime?, bool> OnTimeReached { get; set; }
        public Func<DateTime?, bool> OnTaskCompleted { get; set; }

        public void Dispose()
        {
            StopCheckTask(null);
        }

        private void StopCheckTask(TaskViewModel obj)
        {
            if (_token == null)
                return;

            _token.Cancel();
            _token.Token.WaitHandle.WaitOne(_exitWait);
            _token.Dispose();
            _token = null;
        }

        private async void StartCheckTask(TaskViewModel obj)
        {
            _token?.Dispose();

            using (_token = new CancellationTokenSource())
            {
                await Task.Factory.StartNew(RunTask, _token.Token);
                OnTaskCompleted?.Invoke(DateTime.Now);
            }
        }

        private void RunTask()
        {
            for (;;)
            {
                if (_token.IsCancellationRequested)
                    break;

                if (TimeIsClose(_waitMsec)) OnTimeReached?.Invoke(DateTime.Now);

                if (_token.Token.WaitHandle.WaitOne(_waitMsec))
                    break;
            }
        }

        private bool TimeIsClose(int waitMsec)
        {
            var hour = DateTime.Now.Hour;
            var minute = DateTime.Now.Minute;
            var minuteShift = waitMsec / (60 * 1000);
            var selected = _model.Timers
                .Where(dayTimer => dayTimer.Hour == hour && dayTimer.Enabled > 0);

            foreach (var dayTimer in selected)
                if (Math.Abs(dayTimer.Minute - minute) < minuteShift)
                    return true;

            return false;
        }
    }
}