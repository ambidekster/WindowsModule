using System;
using Modules.WindowsModule.Runtime.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.WindowsModule.Runtime.Views
{
    [RequireComponent(typeof(Canvas))]
    public abstract class WindowView<T> : MonoBehaviour, IWindowView where T : WindowModel
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private WindowStateAnimator _stateAnimator;

        protected T Model { get; private set; }

        public int SortingOrder => _canvas.sortingOrder;
        
        public Transform Transform { get; private set; }

        public void Initialize(WindowModel model, int sortingOrder)
        {
            Transform = transform;
            
            _canvas.overrideSorting = true;
            _canvas.sortingOrder = sortingOrder;
         
            Model = model as T;
            OnInitialize(Model);
        }
    
        protected virtual void OnInitialize(T model)
        {
            
        }

        public void StartShow(Action completeCallback = null)
        {
            OnShowStarted();
            _stateAnimator.StartShowAnimation(() =>
            {
                completeCallback?.Invoke();
                SubscribeActions();
                OnShowCompleted();
            });
        }

        protected virtual void OnShowStarted()
        {
        }

        protected virtual void OnShowCompleted()
        {
        }
        
        public void StartHide(Action completeCallback = null)
        {
            UnsubscribeActions();
            OnHideStarted();
            _stateAnimator.StartHideAnimation(() =>
            {
                completeCallback?.Invoke();
                OnHideCompleted();
            });
        }

        protected virtual void OnHideStarted()
        {
        }

        protected virtual void OnHideCompleted()
        {
        }
        
        private void HandleCloseButtonClicked()
        {
            Model.CloseButtonClicked?.Invoke();
        }

        private void SubscribeActions()
        {
            if(_closeButton)
            {
                _closeButton.onClick.AddListener(HandleCloseButtonClicked);
            }
            
            OnSubscribeActions();
        }

        protected virtual void OnSubscribeActions()
        {
            
        }
        
        private void UnsubscribeActions()
        {
            if(_closeButton)
            {
                _closeButton.onClick.RemoveListener(HandleCloseButtonClicked);
            }
            
            OnUnsubscribeActions();
        }
        
        protected virtual void OnUnsubscribeActions()
        {
            
        }
    }
}