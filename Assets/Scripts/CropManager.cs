using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    private List<GameObject> _growableLocations;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check to see if the colliding object is a enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Damage player HP total
            _gameManager.playerStats.PlayerHp -= collision.gameObject.GetComponent<EnemyController>().damageAmount;
            collision.gameObject.GetComponent<EnemyController>().DieWithNoMoney();
        }
    }
}
