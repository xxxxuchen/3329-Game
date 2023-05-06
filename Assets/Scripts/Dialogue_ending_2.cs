using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue_ending_2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float speed;
    public Princess_ending_2 princess;
    public prince prince;
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
        if (Input.GetMouseButtonDown(0)  && playing == false){
            if (textComponent.text == lines[index]){
                NextLine();
            }
            else{
                StopAllCoroutines();
                textComponent.text = lines[index];
                //SceneManager.LoadScene("Thank");
            }
        }
    }

    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        if (index == 4){
            playing = true;
            princess.start = true;
            yield return new WaitForSeconds(3);
            prince.start = true;
            princess.stop = true;
            yield return new WaitForSeconds(0.5f);
            prince.drop = true;
            yield return new WaitForSeconds(0.5f);
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
