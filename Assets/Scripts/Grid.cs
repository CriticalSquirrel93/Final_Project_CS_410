using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private List<GameObject> _tiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            _tiles.Add(child.gameObject);
        }
    }

    public GameObject GetTile(int x, int y)
    {
        Vector2 targetTileVector = new Vector2(x, y);

        foreach (GameObject tile in _tiles)
        {
            if (tile.GetComponent<Tile>().GetLocalVectorInGrid() == targetTileVector)
            {
                return tile.gameObject;
            }
        }

        return null;
    }
    
}
