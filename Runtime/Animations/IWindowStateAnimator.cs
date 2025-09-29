using System;

namespace Modules.WindowsModule.Runtime.Animations
{
    public interface IWindowStateAnimator
    {
        void StartShowAnimation(Action completeCallback = null);
        void StartHideAnimation(Action completeCallback = null);
    }
}