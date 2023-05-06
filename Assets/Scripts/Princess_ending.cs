using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess_ending : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    Transform trans;
    public bool start;
    public Vector2 speed;
    private bool hit;

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
            Debug.Log("Start");
            speed.x = -8;
            rigid2D.velocity = speed;
        }
        else{
            speed.x = 0;
            rigid2D.velocity = speed;
            StartCoroutine(timing());
        }
    }

    IEnumerator timing(){
       yield return new WaitForSeconds(6.5f);
       SceneManager.LoadScene("Thank");
    }

    void OnCollisionEnter2D(Collision2D colInfo){
        if (colInfo.collider.tag == "Player"){
            Debug.Log("hit");
            speed.x = 0;
            rigid2D.velocity = speed;
            hit = true;
        }
    }
}
