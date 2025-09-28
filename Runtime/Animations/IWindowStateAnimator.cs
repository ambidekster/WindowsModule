using System;

namespace Services.WindowsService.Runtime.Animations
{
    public interface IWindowStateAnimator
    {
        void StartShowAnimation(Action completeCallback = null);
        void StartHideAnimation(Action completeCallback = null);
    }
}