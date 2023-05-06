using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue_opening : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float speed;
    private int index;
    public bool hit;
    public Main_character_opening main_c;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        hit = false;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            if (textComponent.text == lines[index]){
                NextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    void NextLine(){
        if (index != 1 ||  hit != false){
            main_c.start = true;
            if (index < lines.Length - 1){
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else{
                gameObject.SetActive(false);
                SceneManager.LoadScene("level1");
            }
        }
    }
}
