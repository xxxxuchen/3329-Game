using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight_ending : MonoBehaviour
{
   private Rigidbody2D rigid2D;
    public bool start;
    public bool stop;
    private Vector2 speed;
    public Animator Animate;

    // Start is called before the first frame update
    void Start()
    {
        start = false; 
        stop = false;
        rigid2D = GetComponent<Rigidbody2D>();
        speed = rigid2D.velocity; 
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true){
            Debug.Log("Prince start");
            speed.x = 6;
            rigid2D.velocity = speed;
            Animate.SetFloat("speed", 8);
            start = false;
        }
        else if (stop == true){
            Debug.Log("Prince stop");
            speed.x = 0;
            rigid2D.velocity = speed;
            Animate.SetFloat("speed", 0);
        }
    }
}
