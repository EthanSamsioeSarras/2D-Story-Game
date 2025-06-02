using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuContainer;
    public GameObject optionsMenuContainer;
    public GameObject controlsMenuContainer;
    public GameObject decisionWindow;
    
    public TMP_Text decisionWindowText;

    private bool isPaused;
    private bool inOptions;
    private bool inControls;

    private string returnContainer;

    private void Awake()
    {
        isPaused = false;
        inOptions = false;
        inControls = false;
        pauseMenuContainer.SetActive(false);
        optionsMenuContainer.SetActive(false);
        controlsMenuContainer.SetActive(false);
        decisionWindow.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

            if (inOptions)
            {
                CloseOptions();
            }

            if (inControls)
            {
                CloseControls();
            }

        }
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenuContainer.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenuContainer.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OpenOptions()
    {
        inOptions = true;
        optionsMenuContainer.SetActive(true);
        pauseMenuContainer.SetActive(false);
    }

    public void CloseOptions()
    {
        inOptions = false;
        optionsMenuContainer.SetActive(false);
        pauseMenuContainer.SetActive(true);
    }

    public void ApplyOptions()
    {
        Debug.Log("Saving Settings");
    }

    public void OpenControls()
    {
        inControls = true;
        controlsMenuContainer.SetActive(true);
        pauseMenuContainer.SetActive(false);

        GetControls();
    }

    public void CloseControls()
    {
        inControls = false;
        controlsMenuContainer.SetActive(false);
        pauseMenuContainer.SetActive(true);
    }

    private void GetControls()
    {
        Debug.Log("Controls found");
    }

    public void Exit()
    {
        Debug.Log("Loading main menu...");

        //Temporary
        decisionWindow.SetActive(false);
        pauseMenuContainer.SetActive(true);
    }

    public void OpenDecisionWindow(string decision)
    {
        Debug.Log(decision);

        decisionWindow.SetActive(true);

        string decisionText = "";

        switch (decision)
        {
            case "Exit":
                pauseMenuContainer.SetActive(false);
                decisionText = "Are you sure you want to quit?";
                break;
            default:
                decisionText = "";
                break;
        }

        returnContainer = decision;
        decisionWindowText.text = decisionText;
    }

    public void CloseDecisionWindow()
    {
        switch (returnContainer)
        {
            case "Exit":
                decisionWindow.SetActive(false);
                pauseMenuContainer.SetActive(true);
                break;
            default:
                Debug.Log("Error: Check OnClick(); method");
                break;
        }

    }

}
