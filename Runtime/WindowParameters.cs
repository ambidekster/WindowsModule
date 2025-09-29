using System;

namespace Modules.WindowsModule.Runtime
{
    public abstract class WindowParameters
    {
        public Action CloseButtonClicked { get; }

        protected WindowParameters(Action closeButtonClicked = null)
        {
            CloseButtonClicked = closeButtonClicked;
        }
    }
}