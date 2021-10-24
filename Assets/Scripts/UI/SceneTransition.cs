using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    
    public Animator sceneTransition;
    public PauseManager pauseManager;
    private string sceneLoading;

    public void LoadScene(string sceneName)
    {
        pauseManager.Play();
        sceneLoading = sceneName;
        sceneTransition.SetTrigger("Scene Transition Start");
    }
    
    public void OnSceneTransitionStartComplete()
    {
        SceneManager.LoadScene(sceneLoading);
        sceneTransition.SetTrigger("Scene Transition End");
        
    }

    public void OnSceneTransitionEndComplete()
    {
        Debug.Log("asdf");
        sceneTransition.SetTrigger("Scene Transition Complete");
    }
    
    
}
