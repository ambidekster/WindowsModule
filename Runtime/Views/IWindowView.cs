using System;
using UnityEngine;

namespace Modules.WindowsModule.Runtime.Views
{
    public interface IWindowView
    {
        int SortingOrder { get; }
        Transform Transform { get; }

        void Initialize(WindowModel model, int sortingOrder);

        void StartShow(Action completeCallback = null);
        void StartHide(Action completeCallback = null);
    }
}