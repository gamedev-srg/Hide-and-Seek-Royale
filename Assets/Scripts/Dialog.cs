using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textcomp;
    private string[] lines;
    private float textspeed;
    private int index;
    void Start()
    {   
        initlines();
        textcomp.text = string.Empty;
        startDialog();
     
    }
    void initlines(){
        textspeed = 0.02f;
        lines = new string[9];
        lines[0]= "Hello and welcome to Hide and Seek Royal! To get to the next dialog please press the Enter key.";
        lines[1] ="Dialog can be also skipped during the writing by clicking Enter, but we hope you read it all.";
        lines[2] = "The goal in HNSR is to find and shoot the hiders, but be carefull, they will escape you.";
        lines[3] = "To move you charecter use W,A,S,D keys. You point with your mouse and can also navigate with it.";
        lines[4] = "To place a trap click the F key, you have two traps at the start, and there are more to find.";
        lines[5] = "But be carful! your trap can hurt you aswell as the enemies.";
        lines[6] = "Notice you have a limited amount of ammo, that also can be found around the map.";
        lines[7] = "Please move past the trucks to start the Tutorial.";
        lines[8] ="See that guy? try to shot him!";

    }
    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Return)){
            if( textcomp.text == lines[index]){
                nextLine();
            }else{
                StopAllCoroutines();
                textcomp.text = lines[index];
            }
        }
    }

    void startDialog(){
        index = 0;
        StartCoroutine(typleLine());
    }
    IEnumerator typleLine(){
        foreach(char ch in lines[index].ToCharArray()){
            textcomp.text += ch;
            yield return new WaitForSeconds(textspeed);
        }
    }
    void nextLine(){
        if( index < lines.Length -1){
            index++;
            textcomp.text = string.Empty;
            StartCoroutine(typleLine());
        }
        else{
            GameObject.FindWithTag("dialogbox").SetActive(false);

        }
    }
}
