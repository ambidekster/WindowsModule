using System;
using Modules.WindowsModule.Runtime.Views;

namespace Modules.WindowsModule.Runtime
{
    public interface IWindowsDisplayController
    {
        void Initialize();
        
        IWindowView ShowWindow(Enum type, WindowParameters parameters);
        void HideWindow(IWindowView view);
    }
}