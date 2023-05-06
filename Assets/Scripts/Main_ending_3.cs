using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_ending_3 : MonoBehaviour
{
    public bool flip;
    // Start is called before the first frame update
    void Start()
    {
        flip = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (flip == true){
            gameObject.transform.localScale = new Vector3(-2, 2, 2);
        }
    }
}
