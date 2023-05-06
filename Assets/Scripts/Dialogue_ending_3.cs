using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue_ending_3 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float speed;
    public knight_ending prince;
    public Main_ending_3 main_c;
    private int index;
    private bool playing;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && playing == false){
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
        if (index == 5){
            playing = true;
            yield return new WaitForSeconds(3);
            prince.start = true;
            yield return new WaitForSeconds(0.5f);
            prince.stop = true;
            main_c.flip = true;
        }
        playing = false;
        foreach(char c in lines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    void NextLine(){
        if (index < lines.Length - 1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            StartCoroutine(timing());
        }
    }

    IEnumerator timing(){
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Thank");
    }
}
