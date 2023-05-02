using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    [SerializeField] private GameObject gridCellPrefab;
    private GameObject[,] _gameGrid;

    public int width = 10;
    public int height = 10;
    [Range(1,1.5f)]
    public float _gridSpaceSize = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        _gameGrid = new GameObject[height, width];

        if (gridCellPrefab == null)
        {
            Debug.LogError("Error: Grid Cell Prefab on the game Grid is not assigned");
            return;
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                _gameGrid[x, y] = Instantiate(gridCellPrefab, new Vector3(x * _gridSpaceSize, 0, y * _gridSpaceSize),
                    Quaternion.identity);
                _gameGrid[x, y].GetComponent<GridCell>().SetPosition(x, y);
                _gameGrid[x, y].transform.parent = transform;
                _gameGrid[x, y].gameObject.name = "Grid Space ( X: " + x.ToString() + " , Y: " + y.ToString() + ")";
            }
        }
    }

    public Vector2Int GetGridPosFromWorld(Vector3 worldPos)
    {
        int x = Mathf.FloorToInt(worldPos.x / _gridSpaceSize);
        int y = Mathf.FloorToInt(worldPos.y / _gridSpaceSize);

        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(y, 0, height);

        return new Vector2Int(x, y);
    }

    public Vector3 GetWorldPosFromGridPos(Vector2Int gridPos)
    {
        float x = gridPos.x * _gridSpaceSize;
        float y = gridPos.y * _gridSpaceSize;

        return new Vector3(x, 0, y);
    }
    
}
