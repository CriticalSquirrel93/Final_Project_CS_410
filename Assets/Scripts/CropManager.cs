using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class CropManager : MonoBehaviour
{
    private List<GameObject> _growableLocations;

    private void OnCollisionEnter(Collision collision)
    {
        // Check to see if the colliding object is a enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy reached crop");
            // Damage player HP total
            PlayerStats.PlayerHp -= collision.gameObject.GetComponent<EnemyController>().damageAmount;
            collision.gameObject.GetComponent<EnemyController>().DieWithNoMoney();
        }
    }
}
