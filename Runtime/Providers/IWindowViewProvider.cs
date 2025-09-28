using UnityEngine;

namespace Services.WindowsService.Runtime.Providers
{
    public interface IWindowViewProvider
    {
        GameObject GetSource(string id);
    }
}