using UnityEngine;

namespace Services.WindowsService.Runtime
{
    public class RootCanvas : MonoBehaviour
    {
        [SerializeField] private Transform _windowsHolder;
        [SerializeField] private Canvas _canvas;

        public Transform WindowsHolder => _windowsHolder;

        private void Awake()
        {
            _canvas.worldCamera = Camera.main;
        }
    }
}