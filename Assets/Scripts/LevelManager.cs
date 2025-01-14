﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            if (Screen.fullScreen)
            {
                Screen.fullScreen = false;
            }
            else
            {
                Screen.fullScreen = true;
            }
        }
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }

    public void LoadGameLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadHelp()
    { 
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
