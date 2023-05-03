using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject prefabBullet;
    public GameObject target;
    private GameObject _bulletSpawner;
    public float bulletSpeed = 1000f;
    public float delayTime = 5.0f;
    private float _delayCount = 0f;
    private bool _doDelay = false;

    void Start()
    {
        _bulletSpawner = transform.Find("BulletSpawner").gameObject;
        target = GameObject.FindWithTag("Enemy");
    }

    void Update() {
        
        // Makes the turret rotate to look at the target
        transform.LookAt(target.transform.position);
        
        if (_doDelay == false) {
            GameObject tempBullet = Instantiate(prefabBullet, _bulletSpawner.transform.position, Quaternion.identity);
            tempBullet.transform.rotation = transform.rotation;
            tempBullet.GetComponent<Rigidbody>().AddForce(tempBullet.transform.forward * bulletSpeed);
            _doDelay = true;
        } else {
            _delayCount = _delayCount + Time.deltaTime;
            if (_delayCount >= delayTime) {
                _doDelay = false;
                _delayCount = 0;
            }
        }
    }
}
