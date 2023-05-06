using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public int speed = 6;

    void Start() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 v = rb.velocity;
        v.x = speed;
        rb.velocity = v;
    }

    void OnBecameInvisible() {
        Destroy(gameObject); 
    }

    
    void OnCollisionEnter2D(Collision2D col) {
        string name = col.gameObject.name;
        if (name=="wall1" || name=="wall2") {
            Destroy(col.gameObject);
        }
        if (name != "Player" && name != "Playerlevel1"){
            Destroy(gameObject);
        }
    }
}
