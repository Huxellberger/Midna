// Copyright Threetee Gang (C) 2017

using UnityEngine;

namespace Assets.Scripts.Components.HUD
{
    public class HUDComponent 
        : MonoBehaviour
    {
        private GameObject _canvas;
        private GameObject _canvasChild;
        private Canvas _canvasComponent;

        void Start()
        {
            InitialiseCanvas();
            InitialiseElements();
        }

        void OnDestroy()
        {
            Destroy(_canvas);
        }

        private void InitialiseCanvas()
        {
            _canvas = new GameObject();

            _canvasComponent = _canvas.AddComponent<Canvas>();
            _canvasComponent.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        private void InitialiseElements()
        {
            _canvasChild = new GameObject();

            _canvasChild.transform.parent = _canvas.transform;
        }
    }
}
