using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{
    // Public variable that contains the speed of the enemy
    public int speed = -5;
    public GameObject fireEffect;
    public AudioClip Healaudio;
    public GameObject player;

    //public int life;
    //public int yourstupidity;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 v = rb.velocity;
        v.x = 0;
        v.y = speed;
        rb.velocity = v;
        rb.angularVelocity = Random.Range(-200, 200);
        Destroy(gameObject, 3);

        //player = GameObject.Find("Player");
        //playerlevel1 = GameObject.FindWithTag("Player");
        //playerlevel1.GetComponent<playerlevel1>();
        //GameObject playerlevel1 = GameObject.Find("Player");
        //life = playerlevel1.life;
        //yourstupidity = playerlevel1.yourstupidity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function called when the enemy collides with another object
    void OnTriggerEnter2D(Collider2D obj)
    {
        string name = obj.gameObject.name;

        // if collided with bullet
        if (name == "bullet(Clone)")
        {
            Playerlevel1.yourstupidity += 10;
            //GameObject.Find("Player").GetComponent<Playerlevel1>().yourstupidity += 10;
            Instantiate(fireEffect, transform.position, Quaternion.identity);
            // Destroy itself (the enemy)
            Destroy(gameObject);

            // And destroy the bullet
            Destroy(obj.gameObject);
        }

        // if collided with the spaceship
        if (name == "Playerlevel1")
        {
            Playerlevel1.life += 20;
            //player.GetComponent("playerlevel1").life += 20;
            Instantiate(fireEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(Healaudio, transform.position);
            // destroy itself (the enemy) to keep things simple
            Destroy(gameObject);
        }
    }

}
