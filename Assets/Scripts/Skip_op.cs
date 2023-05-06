using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Skip_op : MonoBehaviour
{
    public Button btn1;

    // Start is called before the first frame update
    void Start()
    {
        btn1.transform.gameObject.SetActive(true);
        btn1.onClick.AddListener(()=>{Debug.Log("Pressed");SceneManager.LoadScene("level1");});
    }

    // Update is called once per frame
    void Update(){
    }
}
