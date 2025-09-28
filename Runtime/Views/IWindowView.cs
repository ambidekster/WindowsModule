using System;
using UnityEngine;

namespace Services.WindowsService.Runtime.Views
{
    public interface IWindowView
    {
        int SortingOrder { get; }
        Transform Transform { get; }

        void Initialize(WindowParameters parameters, int sortingOrder);

        void StartShow(Action completeCallback = null);
        void StartHide(Action completeCallback = null);
    }
}