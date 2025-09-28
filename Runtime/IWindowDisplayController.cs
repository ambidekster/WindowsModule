using System;
using Services.WindowsService.Runtime.Views;

namespace Services.WindowsService.Runtime
{
    public interface IWindowDisplayController
    {
        event EventHandler<WindowState> StateChanged;
        
        WindowType WindowType { get; }
        IWindowView View { get; }
        WindowState State { get; }

        void Initialize(WindowParameters parameters, int sortingOrder);
        void StartShow();
        void StartHide();
    }
}