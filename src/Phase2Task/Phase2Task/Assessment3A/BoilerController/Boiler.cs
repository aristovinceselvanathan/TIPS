using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace BoilerController
{

    public partial class Boiler : IDisposable
    {
        private delegate void changedBoilerStateEventHandler();
        private event changedBoilerStateEventHandler changedBoilerState;
        private BoilerStatus _currentBoilerState;
        private InterLock interLock;
        private System.Timers.Timer BoilerStageTimer;
        private int _countDown;
        public static object lockObject = new object();
        private static Boiler _boilerInstance;

        public BoilerStatus currentBoilerStatus { get { return _currentBoilerState; } }

        public InterLock currentInterLockStatus
        {
            get
            {
                return interLock;
            }
        }
        public Reset resetLock { get; private set; }

        public Boiler()
        {
            _currentBoilerState = BoilerStatus.Lockout;
            FileOperation.LogToTheFile(Resource.Resource1.Lockout);
            interLock = new InterLock();
            _countDown = 10;
        }

        public void SwitchInterLock()
        {
            if (interLock.InterLockSwitch == InterLock.InterLockState.Open)
            {
                FileOperation.LogToTheFile(Resource.Resource1.InterLockClosed);
                interLock.ToggleInterLock();
                _currentBoilerState = BoilerStatus.Ready;
                FileOperation.LogToTheFile(Resource.Resource1.Ready);
            }
            else
            {
                FileOperation.LogToTheFile(Resource.Resource1.InterLockOpen);
                interLock.ToggleInterLock();
                _currentBoilerState = BoilerStatus.Lockout;
                FileOperation.LogToTheFile(Resource.Resource1.Lockout);
                _countDown = 10;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ResetLock()
        {
            try
            {
                if (interLock.InterLockSwitch == InterLock.InterLockState.Open)
                {
                    throw new Exception("Interlock is Open - Please Close the InterClock");
                }
                else
                {
                    resetLock = Reset.Closed;
                    FileOperation.LogToTheFile(Resource.Resource1.ResetLockClosed);
                }
            }
            catch (Exception ex)
            {
                FileOperation.LogToTheFile($"{ex.Message}", true);
            }
        }

        public void StartTheSequence()
        {
            if (interLock.InterLockSwitch == InterLock.InterLockState.Closed && resetLock == Reset.Closed &&
                (_currentBoilerState == BoilerStatus.Ready || _currentBoilerState == BoilerStatus.PrePurge && _countDown != 0))
            {
                PrePurge();
            }
            else if (interLock.InterLockSwitch == InterLock.InterLockState.Closed && resetLock == Reset.Closed &&
                (_currentBoilerState == BoilerStatus.PrePurge || _currentBoilerState == BoilerStatus.Ignition && _countDown != 0))
            {
                Ignition();
            }
            else if (interLock.InterLockSwitch == InterLock.InterLockState.Closed && resetLock == Reset.Closed && _currentBoilerState == BoilerStatus.Ignition)
            {
                Operational();
                return;
            }
            else if (_currentBoilerState == BoilerStatus.Operational)
            {
                FileOperation.LogToTheFile(Resource.Resource1.Operational);
            }
            else if (resetLock == Reset.Open)
            {
                FileOperation.LogToTheFile(Resource.Resource1.ResetLockOpen, true);
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                FileOperation.LogToTheFile(Resource.Resource1.InterLockOpen, true);
                return;
            }
            ConsoleKey consoleKey = Console.ReadKey(true).Key;
            if (consoleKey == ConsoleKey.Escape)
            {
                BoilerStageTimer.Elapsed -= OnTimedEvent;
                BoilerStageTimer.Stop();
            }
            else if (consoleKey == ConsoleKey.E)
            {
                ThrowBoilerException();
            }
            resetLock = Reset.Open;
        }

        private void ThrowBoilerException()
        {
            try
            {
                throw new Exception(Resource.Resource1.BoilerException);
            }
            catch (Exception ex)
            {
                BoilerStageTimer.Elapsed -= OnTimedEvent;
                BoilerStageTimer.Stop();
                FileOperation.LogToTheFile($"Safety Mechanism Triggered : {ex.Message}");
                interLock.ToggleInterLock();
                resetLock = Reset.Open;
            }
        }
        private void PrePurge()
        {
            _currentBoilerState = BoilerStatus.PrePurge;
            changedBoilerState += Ignition;
            TimerStart();
        }
        private void Ignition()
        {
            _currentBoilerState = BoilerStatus.Ignition;
            changedBoilerState += Operational;
            if (BoilerStageTimer.Enabled == false)
            {
                BoilerStageTimer.Elapsed += OnTimedEvent;
                BoilerStageTimer.Enabled = true;
                BoilerStageTimer.Start();
            }
        }

        private void Operational()
        {
            Console.Clear();
            _currentBoilerState = BoilerStatus.Operational;
            BoilerStageTimer.Elapsed -= OnTimedEvent;
            FileOperation.LogToTheFile(Resource.Resource1.Operational);
            Console.WriteLine(Resource.Resource1.ContinueString);
        }
        private void TimerStart()
        {
            BoilerStageTimer = new System.Timers.Timer(1000);
            BoilerStageTimer.Elapsed += OnTimedEvent;
            BoilerStageTimer.Start();
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Boiler State : {_currentBoilerState}");
            Console.WriteLine($"Countdown : {_countDown--}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Resource.Resource1.ContinueInTimer);
            if (_countDown == 0)
            {
                _countDown = 10;
                _currentBoilerState = BoilerStatusSwitch(_currentBoilerState);
                changedBoilerState.Invoke();
            }
        }
        private BoilerStatus BoilerStatusSwitch(BoilerStatus currentBoilerStatus)
        {
            if (_currentBoilerState == BoilerStatus.PrePurge)
            {
                return BoilerStatus.Ignition;
            }
            return BoilerStatus.Operational;
        }
        public void Dispose()
        {
            _boilerInstance = null;
            BoilerStageTimer = null;
        }
    }
}
