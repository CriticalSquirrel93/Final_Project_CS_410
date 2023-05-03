using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bullet;
    public GameObject target;
    public float bulletSpeed = 300f;
    public float delayTime = 1.0f;
    private float delayCount = 0f;
    private bool doDelay = false;

    void Start() {
        
    }

    void Update() {
        transform.LookAt(target.transform.position);

        if (doDelay == false) {
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.transform.position = this.transform.position;
            tempBullet.transform.rotation = this.transform.rotation;
            tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            doDelay = true;
        } else {
            delayCount = delayCount + Time.deltaTime;
            if (delayCount >= delayTime) {
                doDelay = false;
                delayCount = 0;
            }
        }
    }
}
