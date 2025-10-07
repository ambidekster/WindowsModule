using System;

namespace Modules.WindowsModule.Runtime
{
    public abstract class WindowModel
    {
        public Action CloseButtonClicked { get; }

        protected WindowModel(Action closeButtonClicked = null)
        {
            CloseButtonClicked = closeButtonClicked;
        }
    }
}