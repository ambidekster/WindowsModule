using System;

namespace Services.WindowsService.Runtime.Animations.SpecificAnimators
{
    public class EmptyWindowStateAnimator : WindowStateAnimator
    {
        public override void StartShowAnimation(Action completeCallback = null)
        {
            WindowTransform.gameObject.SetActive(true);
            completeCallback?.Invoke();
        }

        public override void StartHideAnimation(Action completeCallback = null)
        {
            WindowTransform.gameObject.SetActive(false);
            completeCallback?.Invoke();
        }
    }
}