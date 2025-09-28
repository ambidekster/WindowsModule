using System;
using Services.WindowsService.Runtime.Views;

namespace Services.WindowsService.Runtime
{
    public interface IWindowsDisplayController
    {
        void Initialize();
        
        IWindowView ShowWindow(Enum type, WindowParameters parameters);
        void HideWindow(IWindowView view);
    }
}