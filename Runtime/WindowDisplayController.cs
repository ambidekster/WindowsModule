using System;
using Modules.WindowsModule.Runtime.Views;

namespace Modules.WindowsModule.Runtime
{
    internal class WindowDisplayController : IWindowDisplayController
    {
        public event EventHandler<WindowState> StateChanged;
        public Enum WindowType { get; }
        public IWindowView View { get; }

        private WindowState _state;

        public WindowState State
        {
            get => _state;
            
            private set
            {
                if(value != _state)
                {
                    _state = value;
                    StateChanged?.Invoke(this, _state);
                }
            }
        }

        public WindowDisplayController(Enum windowType, IWindowView view)
        {
            WindowType = windowType;
            View = view;
        }
        
        public void Initialize(WindowModel model, int sortingOrder)
        {
            State = WindowState.Undefined;
            View.Initialize(model, sortingOrder);
        }

        public void StartShow()
        {
            State = WindowState.ShowStarted;
            View.StartShow(() => State = WindowState.ShowCompleted);
        }

        public void StartHide()
        {
            State = WindowState.HideStarted;
            View.StartHide(() => State = WindowState.HideCompleted);
        }
    }
}