using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private Camera sceneCamera;
    [SerializeField] private LayerMask isBuildableLayer;
    [SerializeField] private LayerMask isGrowableLayer;

    private GameManager _gameManager;
    
    private Tile _selectedTile;
    private GameObject _selectedBuildable;
    private static BuildManager _instance;
    private int _cost;

    private void Start()
    {
        _cost = 0;
        _selectedBuildable = null;
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    { 
        // OnLeftClick
        if (Input.GetMouseButtonDown(0))
        {
            // If we are trying to build something, build it.
            if (_selectedBuildable != null)
            {
                _cost = _selectedBuildable.GetComponent<Tower>().TowerCost;
                if (_cost <= _gameManager.playerStats.Money)
                {
                    SelectTile(isBuildableLayer);
                    _gameManager.playerStats.Money -= _cost;
                }

                if (_selectedTile != null)
                {
                    PlaceBuildable(_selectedBuildable);
                }
            }
            
            // If Shift is depressed, continue building that buildable
            if (Input.GetKey(KeyCode.LeftShift))
            {
                DeselectTile();
            }
            else
            {
                // otherwise clear everything
                ClearBuildable();
                DeselectTile();
            }

            // If the shift key is let go, clear the selected buildable
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                ClearBuildable();
            }
        }
        
        // OnRightClick
        if (Input.GetMouseButtonDown(1))
        {
            // Get the node we are pointing at.
            if (_selectedBuildable.CompareTag("Tower") || _selectedBuildable.CompareTag("Wall")) {
                SelectTile(isBuildableLayer);
            } else if (_selectedBuildable.CompareTag("Crop")) {
                SelectTile(isGrowableLayer);
            }
            
            // If there is something there, delete it.
            if (_selectedTile.itemOccupying != null)
            {
                DestroyBuildable();
            }
        }
    }

    void Awake()
    {
        // Upon wakeup, ensure that this is the only build manager active.
        // We can end up in a wiggy situation if two managers are active at once.
        if (_instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        
        // There is only one manager, set it to this object
        _instance = this;
    }

    public void SelectTile(LayerMask nodeMask)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, nodeMask))
        {
            _selectedTile = hit.collider.gameObject.GetComponent<Tile>();
            Debug.Log("Selected x: " + _selectedTile.GetCartesianXPos() + ",Y: " + _selectedTile.GetCartesianYPos());
        }
    }

    public void DeselectTile()
    {
        _selectedTile = null;
    }

    public void SetBuildable(GameObject buildable)
    {
        Debug.Log("Selected " + buildable.gameObject.name);
        _selectedBuildable = buildable;
        DeselectTile();
    }

    public void ClearBuildable()
    {
        Debug.Log("Attempted to clear buildable.");
        _selectedBuildable = null;
        _cost = 0;
    }
    
    public void PlaceBuildable(GameObject buildable)
    {
        Debug.Log("Should have placed something.");
        if (_selectedTile != null && _selectedBuildable != null)
        {
            _selectedTile.SetItem(buildable);
        }
    }

    public void DestroyBuildable()
    {
        Debug.Log("Should have destroyed something.");
        if (_selectedTile != null)
        {
            _selectedTile.RemoveItem();
        }
    }
}
