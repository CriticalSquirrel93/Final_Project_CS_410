using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    private int _posX;
    private int _posY;

    public GameObject objectInThisGridSpace = null;
    
    public bool IsOccupied { get; set; }

    public void SetPosition(int x, int y)
    {
        _posX = x;
        _posY = y;
    }

    public Vector2Int GetPosition()
    {
        return new Vector2Int(_posX, _posY);
    }
}
