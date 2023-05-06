using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitGunBlock : MonoBehaviour
{
    public GameObject gun;
    bool isHit = false;

    void OnCollisionEnter2D(Collision2D col) {
        if ((col.relativeVelocity[1]>9) && (!isHit)) {
            isHit = true;
            gun.SetActive(true);
        }
    }
}
