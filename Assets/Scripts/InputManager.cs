using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField] private LayerMask gridLayerMask;

    private Grid _gameGrid;


    // Start is called before the first frame update
    void Start()
    {
        _gameGrid = FindObjectOfType<Grid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GridCell cellMouseIsOver = IsMouseOverAGridSpace();
            
            if (cellMouseIsOver != null)
            {
                if (cellMouseIsOver.GetComponent<MeshRenderer>().material.color != Color.green || cellMouseIsOver.GetComponent<MeshRenderer>().material.color != Color.red)
                {
                    cellMouseIsOver.GetComponent<MeshRenderer>().material.color = Color.green;
                } else if (cellMouseIsOver.GetComponent<MeshRenderer>().material.color == Color.green)
                {
                    cellMouseIsOver.GetComponent<MeshRenderer>().material.color = Color.red;
                    cellMouseIsOver.IsOccupied = true;
                } else if (cellMouseIsOver.GetComponent<MeshRenderer>().material.color == Color.red)
                {
                    cellMouseIsOver.GetComponent<MeshRenderer>().material.color = Color.green;
                    cellMouseIsOver.IsOccupied = false;
                }
                
                Debug.Log(cellMouseIsOver.IsOccupied);
            }
        }
    }

    private GridCell IsMouseOverAGridSpace()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, gridLayerMask))
        {
            return hitInfo.transform.GetComponent<GridCell>();
        }
        else
        {
            return null;
        }
    }
}
