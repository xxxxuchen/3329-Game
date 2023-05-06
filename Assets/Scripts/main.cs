using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public GameObject text;
    public Button btn1, btn2, btn3;

    void Start()
    {
        text.SetActive(true);
        btn1.transform.gameObject.SetActive(false);
        btn2.transform.gameObject.SetActive(false);
        btn3.transform.gameObject.SetActive(false);

        btn1.onClick.AddListener(()=>{SceneManager.LoadScene("opening");});
        btn2.onClick.AddListener(()=>{SceneManager.LoadScene("level2");});
        btn3.onClick.AddListener(()=>{SceneManager.LoadScene("level3");});
    }

    void Update()
    {
        if (Input.anyKey){
            text.SetActive(false);
            btn1.transform.gameObject.SetActive(true);
            btn2.transform.gameObject.SetActive(true);
            btn3.transform.gameObject.SetActive(true);
        }
    }
}