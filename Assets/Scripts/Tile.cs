using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour
{

    private GameObject _tilePrefab;
    public GameObject itemOccupying;

    [SerializeField] private float xPos;
    [SerializeField] private float yPos;

    private void Start()
    {
        // Set the initial values
        Vector3 pos = transform.position;
        xPos = pos.x;
        yPos = pos.z;
    }
    
    // Return the grid coordinate on the x axis (XY axis on grid, XZ axis in world)
    public float GetCartesianXPos()
    {
        return xPos;
    }

    // Return the grid coordinate on the y/z axis (XY axis on grid, XZ axis in world)
    public float GetCartesianYPos()
    {
        return yPos;
    }

    // Sets the occupying item for the grid space. Instantiates that object if the tile is empty. If not errors.
    public void SetItem(GameObject item)
    {
        if (itemOccupying == null)
        {
            itemOccupying = Instantiate(item, new Vector3(xPos, transform.position.y + transform.lossyScale.y, yPos), Quaternion.identity);
            itemOccupying.transform.parent = transform;
        }
        else
        {
            Debug.LogError("Cannot place a object in a spot that is already occupied!");
        }
        
    }

    // Remove the item occupying the tile.
    public void RemoveItem()
    {
        if (itemOccupying != null)
        {
            DestroyImmediate(transform.GetChild(1).gameObject);
        }
        else
        {
            Debug.LogError("Cannot destroy item that does not exist.");
        }
    }
    
    // Gets local xy pos as a vector 2. Not likely to be used a whole lot.
    public Vector2 GetLocalVectorInGrid()
    {
        return new Vector2(xPos, yPos);
    }
}
