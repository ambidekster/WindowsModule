using System;
using Services.WindowsService.Runtime.Views;

namespace Services.WindowsService.Runtime
{
    public class WindowDisplayController : IWindowDisplayController
    {
        public event EventHandler<WindowState> StateChanged;
        public WindowType WindowType { get; }
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

        public WindowDisplayController(WindowType windowType, IWindowView view)
        {
            WindowType = windowType;
            View = view;
        }
        
        public void Initialize(WindowParameters parameters, int sortingOrder)
        {
            State = WindowState.Undefined;
            View.Initialize(parameters, sortingOrder);
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