using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public GameObject gun;
    public GameObject hint;
    public GameObject ring;
    public GameObject princess;
    public GameObject bullet;
    public GameObject coin;

    bool isGunGet = false;
    bool isRingGet = false;
    bool isCoinGet = false;


    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name=="monster") {
            SceneManager.LoadScene("level3");
        }
    }
    

    private void OnTriggerEnter2D(Collider2D col){
        if((col.gameObject.name=="gun") && (!isGunGet)) {
            Destroy(gun);
            isGunGet = true;
            hint.SetActive(true);
        } else if ((col.gameObject.name=="ring") && (!isRingGet)) {
            Destroy(ring);
            isRingGet = true;
            isGunGet = false;
            hint.SetActive(false);
        } else if ((col.gameObject.name == "coin") && (!isRingGet)) {
            Destroy(coin);
            isCoinGet = true;
            hint.SetActive(false);
        }

        if (col.gameObject.name=="Princess") {
            if (isRingGet) {
                SceneManager.LoadScene("ending2");
            } else {
                SceneManager.LoadScene("ending1");
            }
        }
    }

    private void Update() {        
        if (transform.position.y < -10) {
            SceneManager.LoadScene("level3");
        }

        if(isGunGet && Input.GetKeyDown(KeyCode.F)){
            Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 180f));
        }
    }
}
