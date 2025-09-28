using Services.WindowsService.Runtime.Views;

namespace Services.WindowsService.Runtime
{
    public interface IWindowsDisplayController
    {
        void Initialize();
        
        IWindowView ShowWindow(WindowType type, WindowParameters parameters);
        void HideWindow(IWindowView view);
    }
}