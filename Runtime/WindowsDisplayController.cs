using System;
using System.Collections.Generic;
using System.Linq;
using CommonSolutions.Runtime.Extensions;
using CommonSolutions.Runtime.Pool;
using CommonSolutions.Runtime.Providers.Assets;
using Services.WindowsService.Runtime.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.WindowsService.Runtime
{
    public class WindowsDisplayController : IWindowsDisplayController
    {
        private readonly List<IWindowDisplayController> _activeWindows = new List<IWindowDisplayController>();
        
        private RootCanvas _rootCanvas;
        
        private readonly IObjectsPool _windowsPool;
        private readonly GameObject _rootCanvasPrefab;
        private readonly IAssetProvider<GameObject> _windowPrefabProvider;

        public WindowsDisplayController(GameObject rootCanvasPrefab, 
                                        IAssetProvider<GameObject> windowPrefabProvider)
        {
            _windowsPool = new ObjectsPool("Windows");
            
            _rootCanvasPrefab = rootCanvasPrefab;
            _windowPrefabProvider = windowPrefabProvider;
        }

        public void Initialize()
        {
            _rootCanvas = Object.Instantiate(_rootCanvasPrefab).GetComponent<RootCanvas>();
            _rootCanvas.name = "RootCanvas";
        }

        public IWindowView ShowWindow(Enum type, WindowParameters parameters)
        {
            var windowView = GetWindowView(type);
            if(windowView != null)
            {
                IWindowDisplayController windowDisplayController = new WindowDisplayController(type, windowView);
                windowDisplayController.StateChanged += HandleWindowStateChanged;

                var currentWindow = GetCurrentWindow();
                var sortingOrder = currentWindow != null ? currentWindow.View.SortingOrder + 1 : 0;
                windowDisplayController.Initialize(parameters, sortingOrder);
                windowDisplayController.StartShow();   
                
                _activeWindows.Add(windowDisplayController);
                return windowView;
            }

            Debug.LogError($"Invalid window type: {type}");
            return null;
        }
        
        private IWindowDisplayController GetCurrentWindow() => _activeWindows.LastOrDefault();

        private IWindowView GetWindowView(Enum type)
        {
            var prefab = _windowPrefabProvider.GetAsset(type.ToString());
            return _windowsPool.Instantiate(prefab, _rootCanvas.WindowsHolder)
                               .GetComponent<IWindowView>();
        }

        public void HideWindow(IWindowView windowView)
        {
            var window = _activeWindows.FirstOrDefault(w => w.View == windowView,
                    $"Can't find active window for hide");

            if(window != null)
            {
                window.StartHide();
            }
        }
        
        private void HandleWindowStateChanged(object sender, WindowState state)
        {
            if(state == WindowState.HideCompleted)
            {
                var window = (IWindowDisplayController)sender;
                window.StateChanged -= HandleWindowStateChanged;
                
                _windowsPool.Return(window.View.Transform.gameObject);
                _activeWindows.Remove(window);
            }
        }
    }
}