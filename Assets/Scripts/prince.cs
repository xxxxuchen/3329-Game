using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prince : MonoBehaviour
{
   private Rigidbody2D rigid2D;
    public bool start;
    private Vector2 speed;
    public Animator Animate;
    public bool drop;

    // Start is called before the first frame update
    void Start()
    {
        start = false; 
        drop = false;
        rigid2D = GetComponent<Rigidbody2D>();
        speed = rigid2D.velocity; 
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true){
            Debug.Log("Prince start");
            speed.x = 6;
            speed.y = 5;
            rigid2D.velocity = speed;
            Animate.SetFloat("speed", 8);
            start = false;
        }
        else if (drop == true){
            Debug.Log("Prince drop");
            speed.x = 6;
            speed.y = 0;
            rigid2D.velocity = speed;
            Animate.SetFloat("speed", 0);
            drop = false;
        }
    }

    void OnCollisionEnter2D(Collision2D colInfo){
        if (colInfo.collider.tag == "Princess"){
            Debug.Log("Prince hit");
            speed.x = 0;
            rigid2D.velocity = speed;
        }
    }
}
