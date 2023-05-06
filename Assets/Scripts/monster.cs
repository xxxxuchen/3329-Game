using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour {
    public float speed = 0f;
    private Rigidbody2D rb;
    private Vector2 v;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "bullet") {
            Destroy(col.gameObject);
            speed -= 10;
        }
    }

    void Update() {
        rb = GetComponent<Rigidbody2D>();
        v = rb.velocity; 
        v.x = speed;
        rb.velocity = v;
    }
}
