using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Timing : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(timing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator timing(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene);
    }
}
