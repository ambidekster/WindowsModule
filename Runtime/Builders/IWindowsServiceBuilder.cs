using CommonSolutions.Runtime.Providers.Assets;
using UnityEngine;

namespace Services.WindowsService.Runtime.Builders
{
    public interface IWindowsServiceBuilder
    {
        public IWindowsServiceBuilder WithWindowPrefabProvider(IAssetProvider<GameObject> provider);
        public IWindowsServiceBuilder WithRootCanvas(GameObject rootCanvas);
        
        public IWindowsDisplayController Build();
    }
}