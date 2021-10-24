using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenu;
    [HideInInspector] public bool isPaused;
    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        PauseMenu.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Play();
            }
            else
            {
                Pause();
            }
        }
    }
}
