using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Scene m_Scene;
    private string sceneName;
    private void Start(){
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
    }
    public void Update(){
        if(sceneName == "eDemo" || sceneName == "Win"){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Play(){
        SceneManager.LoadScene("Scene1");
    }
    public void Demo(){
        SceneManager.LoadScene("Demo");
    }
    public void Quit(){
        Application.Quit();
    }
    public void Replay(){
        SceneManager.LoadScene("Scene1");
        
    }
}
