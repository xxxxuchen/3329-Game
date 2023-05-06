using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_character_opening : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    public Vector2 speed;
    private bool hit;
    public bool start;
    public Dialogue_opening dialogue;
    public Animator Animate;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        speed = rigid2D.velocity; 
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == false && start == true){
            Animate.SetFloat("Speed", 5);
            speed.x = 5;
            rigid2D.velocity = speed;
        }
    }

    void OnCollisionEnter2D(Collision2D colInfo){
        if (colInfo.collider.tag == "envolope"){
            Debug.Log("hit");
            speed.x = 0;
            rigid2D.velocity = speed;
            Animate.SetFloat("Speed", 0);
            hit = true;
            dialogue.hit = true;
        }
    }
}
