using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    // Start is called before the first frame update
    

    
    public float speed = 10f; // adjust the speed as per your requirement
    public float topBound = 10f; // set the top boundary for the object
    public float bottomBound = -10f; // set the bottom boundary for the object
    private bool moveUp = false; // flag to track the direction of movement
    private Animator animator; // reference to the animator component
    private bool hasHitBottom = false; // flag to track if the object has hit the bottom

    // Update is called once per frame
    void Start () {
        animator = GetComponent<Animator>(); // get the animator component on start
    }

    void Update () {
        if (transform.position.y <= bottomBound) {
            if (!hasHitBottom) {
                hasHitBottom = true;
                animator.SetBool("hitBottom", true); // set the "hitBottom" parameter to true when the object starts hitting the bottom
            }
            moveUp = true;
        } else if (transform.position.y >= topBound) {
            moveUp = false;
            hasHitBottom = false; // reset the flag when the object hits the top boundary
            animator.SetBool("hitBottom", false); // set the "hitBottom" parameter to false when the object hits the top
        }

        if (moveUp) {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        } else {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}


