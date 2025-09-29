using CommonSolutions.Runtime.Providers.Assets;
using UnityEngine;

namespace Modules.WindowsModule.Runtime.Builders
{
    public interface IWindowsModuleBuilder
    {
        public IWindowsModuleBuilder WithWindowPrefabProvider(IAssetProvider<GameObject> provider);
        public IWindowsModuleBuilder WithRootCanvas(GameObject rootCanvas);
        
        public IWindowsDisplayController Build();
    }
}