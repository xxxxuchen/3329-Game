using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlevel1 : MonoBehaviour
{
    public GameObject gun;
    public GameObject gunhint;
    public GameObject ring;
    public GameObject princess;
    public GameObject bullet;
    public GameObject coin;
    public GameObject coinhint;

    GUIStyle guiStyle;

    bool isGunGet = false;
    bool isRingGet = false;
    bool isCoinGet = false;

    public static int yourstupidity;
    public static int life;

    void Start()
    {
        yourstupidity = 0;
        life = 100;
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 40;
        guiStyle.normal.textColor = Color.white;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name=="monster") {
            life -= 50;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D col){
        if((col.gameObject.name=="gun") && (!isGunGet)) {
            Destroy(gun);
            isGunGet = true;
            gunhint.SetActive(true);
            coinhint.SetActive(false);
        } else if ((col.gameObject.name=="ring") && (!isRingGet)) {
            Destroy(ring);
            isRingGet = true;
            isGunGet = false;
            gunhint.SetActive(false);
            coinhint.SetActive(false);
        } else if ((col.gameObject.name == "coin") && (!isRingGet)) {
            Destroy(coin);
            isCoinGet = true;
            life -= 20;
            yourstupidity += 10;
            gunhint.SetActive(false);
            coinhint.SetActive(true);
        }
        
        if (col.gameObject.name == "meteor") {
            life += 20;
        }

        if (col.gameObject.name=="Princess") {
            if (isRingGet) {
                SceneManager.LoadScene("main");
            } else {
                SceneManager.LoadScene("main");
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(30, 300, 2000, 2000), "Your stupidity: " + yourstupidity, guiStyle);
        GUI.Label(new Rect(30, 350, 2000, 2000), "Life: " + life, guiStyle);
    }

    private void Update() {        
        if (transform.position.y < -10 || life <= 0) {
            SceneManager.LoadScene("level1");
        }

        if(isGunGet && Input.GetKeyDown(KeyCode.F)){
            Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 180f));
        }
    }
}
