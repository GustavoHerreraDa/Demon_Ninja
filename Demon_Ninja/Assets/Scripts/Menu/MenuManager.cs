﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas controlMenuCanvas;
    public Canvas creditsMenuCanvas;
    public Canvas playMenuCanvas;
    public int menuState = 1;
    void Start()
    {
        /* mainMenuCanvas = GameObject.Find("MainMenu").GetComponent<Canvas>();
         controlMenuCanvas = GameObject.Find("ControlsMenu").GetComponent<Canvas>();
         creditsMenuCanvas = GameObject.Find("CreditsMenu").GetComponent<Canvas>();
         playMenuCanvas = GameObject.Find("LevelSelectMenu").GetComponent<Canvas>();*/
        menuState = 1;
    }

    void Update()
    {
        CheckMenuState();

    }
    public void CheckMenuState()
    {
        switch (menuState)
        {
            case 1:
                mainMenuCanvas.enabled = true;
                controlMenuCanvas.enabled = false;
                creditsMenuCanvas.enabled = false;
                playMenuCanvas.enabled = false;
                break;
            case 2:
                mainMenuCanvas.enabled = false;
                controlMenuCanvas.enabled = false;
                creditsMenuCanvas.enabled = false;
                playMenuCanvas.enabled = true;
                break;
            case 3:
                mainMenuCanvas.enabled = false;
                controlMenuCanvas.enabled = true;
                creditsMenuCanvas.enabled = false;
                playMenuCanvas.enabled = false;
                break;
            case 4:
                mainMenuCanvas.enabled = false;
                controlMenuCanvas.enabled = false;
                creditsMenuCanvas.enabled = true;
                playMenuCanvas.enabled = false;
                break;
        }
    }

    public void OnClick(int state)
    {
        menuState = state;
    }
    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void DoExitGame()
    {
        Application.Quit();
    }

    public void StartGameViking()
    {

    }

    public void StartGameViking()
    {

    }

    public void StarGameNinja()
    {

    }

}