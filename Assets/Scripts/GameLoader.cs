using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    public GameObject pause;
    public GameObject dataHolder;
    public UIManager uiNavigation;
    public GameObject sceneTransition;
    private void Awake()
    {
        DontDestroyOnLoad(dataHolder);
        DontDestroyOnLoad(pause);
        DontDestroyOnLoad(sceneTransition);
        uiNavigation.Init();
    }
    void Start()
    {
        SceneManager.LoadScene("Menu");
    }
}
