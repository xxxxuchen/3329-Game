using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitRingBlock : MonoBehaviour
{
    public GameObject ring;
    public GameObject wall1;
    public GameObject wall2;
    bool isHit = false;

    void OnCollisionEnter2D(Collision2D col) {
        if ((col.relativeVelocity[1]>9) && (!isHit)) {
            isHit = true;
            ring.SetActive(true);
            wall1.SetActive(true);
            wall2.SetActive(true);
        }
    }
}
