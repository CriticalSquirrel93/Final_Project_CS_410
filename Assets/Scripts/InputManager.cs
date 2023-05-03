using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    [SerializeField] private LayerMask isBuildableLayer;
    [SerializeField] private GameObject fireTower;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnTower(fireTower);
        }
    }

    void SpawnTower(GameObject tower)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, isBuildableLayer))
        {
            Vector3 hitPoint = hitInfo.point;

            Instantiate(fireTower, new Vector3(hitPoint.x, hitPoint.y + 0.5f, hitPoint.z), Quaternion.identity);
        }
    }
}
