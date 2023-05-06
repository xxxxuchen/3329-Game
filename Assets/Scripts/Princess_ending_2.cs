using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess_ending_2 : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    Transform trans;
    public bool start;
    public Vector2 speed;
    private bool hit;
    public bool stop;

    // Start is called before the first frame update
    void Start()
    {
        start = false; 
        rigid2D = GetComponent<Rigidbody2D>();
        speed = rigid2D.velocity; 
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true && hit == false){
            Debug.Log("Princess Start");
            speed.x = -8;
            rigid2D.velocity = speed;
        }
        else if (stop == true){
            speed.x = 0;
            rigid2D.velocity = speed;
        }
    }

    void OnCollisionEnter2D(Collision2D colInfo){
        if (colInfo.collider.tag == "Player"){
            Debug.Log("Princess hit");
            speed.x = 24;
            rigid2D.velocity = speed;
            hit = true;
        }
    }
}
