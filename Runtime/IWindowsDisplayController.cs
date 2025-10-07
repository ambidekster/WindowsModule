using System;
using Modules.WindowsModule.Runtime.Views;

namespace Modules.WindowsModule.Runtime
{
    public interface IWindowsDisplayController
    {
        void Initialize();
        
        IWindowView ShowWindow(Enum type, WindowModel model);
        void HideWindow(IWindowView view);
    }
}