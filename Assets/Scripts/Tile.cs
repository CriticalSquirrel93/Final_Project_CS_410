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
        Vector3 pos = transform.position;
        xPos = pos.x;
        yPos = pos.z;
    }

    public float GetCartesianXPos()
    {
        return xPos;
    }

    public float GetCartesianYPos()
    {
        return yPos;
    }

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

    public void RemoveItem()
    {
        if (itemOccupying != null)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        else
        {
            Debug.LogError("Cannot destroy item that does not exist.");
        }
    }

    public Vector2 GetLocalVectorInGrid()
    {
        return new Vector2(xPos, yPos);
    }
}
