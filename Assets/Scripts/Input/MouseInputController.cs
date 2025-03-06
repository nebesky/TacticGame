using System;
using Input.Interfaces;
using UnityEngine;

namespace Input
{
    public class MouseInputController : MonoBehaviour, IMouseInputController
    {
        public event Action<Vector3> OnMouseUp;
        public event Action<Vector3> OnMousePressed;
        public event Action<Vector3> OnMouseDown;
        
        private bool isClicked;
        
        public void Update()
        {
            if (UnityEngine.Input.GetMouseButton(0))
            {
                if (!isClicked)
                {
                    isClicked = true;

                    OnMouseDown?.Invoke(UnityEngine.Input.mousePosition);
                }
                else
                    OnMousePressed?.Invoke(UnityEngine.Input.mousePosition);
            }

            if (!UnityEngine.Input.GetMouseButton(0) && isClicked)
            {
                isClicked = false;
                OnMouseUp?.Invoke(UnityEngine.Input.mousePosition);
            }
        }
    }
}