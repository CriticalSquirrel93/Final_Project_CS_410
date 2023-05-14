using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Shamelessly based on to a fair extent, Brackeys How to make a Tower Defense Game series from youtube
// Link : https://www.youtube.com/playlist?list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0
// Tried to do this several times on my own, and due to time, desperately needed a temporary and editable alternative.


[Serializable]
public class Wave : MonoBehaviour
{
    public GameObject enemy;
    public int count;
    public float rate;
}
