using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour
{
    public Vector2Int coord;
    public int x;
    public int y;
    public string Name;
    public List<Cell> Neighbors = new();
    public Transform centerCell;
    public Action<Transform> OnClick;
    public SpriteRenderer hover;
    public bool isBlocked;
    public CellController cellController;
    public TextMeshPro xT;
    public TextMeshPro yT;
    public TextMeshPro zT;
    public TextMeshPro isProcessed;
    public TextMeshPro fakeName;

    private void Awake()
    {
        cellController.OnMouseEnterAction += MouseEnter;
        cellController.OnMouseDownAction += MouseDown;
        cellController.OnMouseExitAction += MouseExit;
    }

    private void OnDrawGizmosSelected()
    {
        foreach (var neighbor in Neighbors)
        {
            if (neighbor == null) continue;
            var position = neighbor.centerCell.position;

            Gizmos.DrawLine(centerCell.position, position); 
            Gizmos.DrawSphere(position, 0.5f);
        }

        Gizmos.DrawSphere(centerCell.position, 1f);
    }

    private void MouseEnter()
    {
        hover.enabled = !EventSystem.current.IsPointerOverGameObject();
    }
    
    private void MouseExit()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
            hover.enabled = false;
    }

    private void OnMouseOver()
    {
        //add collider for that?
        if (!EventSystem.current.IsPointerOverGameObject())
            hover.enabled = false;
    }

    private void MouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            OnClick.Invoke(centerCell);
        }
    }
}
