using System;
using CommonSolutions.Runtime.Providers.Assets;
using UnityEngine;

namespace Modules.WindowsModule.Runtime.Builders
{
    public class WindowsModuleBuilder : IWindowsModuleBuilder
    {
        private IAssetProvider<GameObject> _windowsPrefabProvider;
        private GameObject _rootCanvasPrefab;
        
        public IWindowsModuleBuilder WithWindowPrefabProvider(IAssetProvider<GameObject> provider)
        {
            _windowsPrefabProvider = provider;
            return this;
        }

        public IWindowsModuleBuilder WithRootCanvas(GameObject rootCanvas)
        {
            _rootCanvasPrefab = rootCanvas;
            return this;
        }

        public IWindowsDisplayController Build()
        {
            if(_windowsPrefabProvider == null)
            {
                Debug.LogException(new Exception($"Invalid window prefab provider!"));
                return null;
            }
            
            if(_rootCanvasPrefab == null)
            {
                Debug.LogException(new Exception($"Invalid root canvas prefab!"));
                return null;
            }
            
            return new WindowsDisplayController(_rootCanvasPrefab, _windowsPrefabProvider);
        }
    }
}