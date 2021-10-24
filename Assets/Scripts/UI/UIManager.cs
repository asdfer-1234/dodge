using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private PauseManager pauseManager;
    private SceneTransition transition;
    

    public void Init()
    {
        pauseManager = GameObject.FindWithTag("Pause").GetComponent<PauseManager>();
        transition = GameObject.Find("Scene Transition").GetComponent<SceneTransition>();

    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void LoadScene(string sceneName)
    {
        transition.LoadScene(sceneName);
    }

    
    
}
