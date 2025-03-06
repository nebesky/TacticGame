using System;
using UnityEngine;

public class CellController : MonoBehaviour
{
    public Action OnMouseExitAction;
    public Action OnMouseEnterAction;
    public Action OnMouseDownAction;
    
    private void OnMouseEnter()
    {
        OnMouseEnterAction?.Invoke();
    }

    private void OnMouseExit()
    {
        OnMouseExitAction?.Invoke();
    }

    private void OnMouseDown()
    {
        OnMouseDownAction?.Invoke();
    }
}
