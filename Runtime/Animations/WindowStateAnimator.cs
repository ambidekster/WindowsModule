using System;
using UnityEngine;

namespace Modules.WindowsModule.Runtime.Animations
{
    public abstract class WindowStateAnimator : MonoBehaviour, IWindowStateAnimator
    {
        [SerializeField] protected RectTransform WindowTransform;

        public abstract void StartShowAnimation(Action completeCallback = null);
        public abstract void StartHideAnimation(Action completeCallback = null);
    }
}