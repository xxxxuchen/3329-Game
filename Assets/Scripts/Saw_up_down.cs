using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_up_down : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 10f; // adjust the speed as per your requirement
    public float topBound = 10f; // set the top boundary for the object
    public float bottomBound = -10f; // set the bottom boundary for the object
    private bool moveUp = false; // flag to track the direction of movement
    
    void Update() {
       if (transform.position.y >= topBound) {
          moveUp = false;
       } else if (transform.position.y <= bottomBound) {
          moveUp = true;
       }
    
       if (moveUp) {
          transform.position += Vector3.up * speed * Time.deltaTime;
       } else {
          transform.position += Vector3.down * speed * Time.deltaTime;
       }
    }
}
