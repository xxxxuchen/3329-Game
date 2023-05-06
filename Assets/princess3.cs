using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class princess3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="bullet") {
            SceneManager.LoadScene("ending3");
        }
    }
}
