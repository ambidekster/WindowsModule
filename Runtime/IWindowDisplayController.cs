using System;
using Modules.WindowsModule.Runtime.Views;

namespace Modules.WindowsModule.Runtime
{
    internal interface IWindowDisplayController
    {
        event EventHandler<WindowState> StateChanged;
        
        Enum WindowType { get; }
        IWindowView View { get; }
        WindowState State { get; }

        void Initialize(WindowParameters parameters, int sortingOrder);
        void StartShow();
        void StartHide();
    }
}