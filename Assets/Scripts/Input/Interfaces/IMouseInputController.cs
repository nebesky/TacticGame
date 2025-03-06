using System;
using UnityEngine;

namespace Input.Interfaces
{
    public interface IMouseInputController
    {
        event Action<Vector3> OnMouseUp;
        event Action<Vector3> OnMousePressed;
        event Action<Vector3> OnMouseDown;
    }
}