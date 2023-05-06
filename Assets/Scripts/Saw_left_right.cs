using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_left_right : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public float speed = 10f; // adjust the speed as per your requirement
    public float leftBound = -10f; // set the left boundary for the object
    public float rightBound = 10f; // set the right boundary for the object
    private bool moveRight = true; // flag to track the direction of movement
    
    void Update() {
       if (transform.position.x >= rightBound) {
          moveRight = false;
       } else if (transform.position.x <= leftBound) {
          moveRight = true;
       }
    
       if (moveRight) {
          transform.position += Vector3.right * speed * Time.deltaTime;
       } else {
          transform.position += Vector3.left * speed * Time.deltaTime;
       }
    }
}
