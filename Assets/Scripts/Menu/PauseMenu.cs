using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public OptionsController optionsController;

    public GameObject pauseMenuContainer;
    public GameObject optionsMenuContainer;
    public GameObject controlsMenuContainer;
    public GameObject decisionWindow;
    
    public TMP_Text decisionWindowText;

    private bool isPaused;
    private bool inOptions;
    private bool inControls;
    private bool inDecision;

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
            if (!inDecision)
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
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
        if (optionsController.hasSaved == false)
        {
            OpenDecisionWindow("Options");
        }
        else
        {
            inOptions = false;
            optionsMenuContainer.SetActive(false);
            pauseMenuContainer.SetActive(true);
        }
    }

    public void ApplyOptions()
    {
        Debug.Log("Saving Settings");
        optionsController.ApplySettings();

        decisionWindow.SetActive(false);
        optionsMenuContainer.SetActive(false);
        pauseMenuContainer.SetActive(true);
    }
    public void DiscardOptions()
    {
        Debug.Log("Discarding Settings");
        optionsController.DiscardSettings();

        decisionWindow.SetActive(false);
        optionsMenuContainer.SetActive(false);
        pauseMenuContainer.SetActive(true);
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
        Application.Quit();
    }

    public void OpenDecisionWindow(string decision)
    {
        Debug.Log(decision);
        inDecision = true;

        decisionWindow.SetActive(true);

        string decisionText = "";

        switch (decision)
        {
            case "Exit":
                pauseMenuContainer.SetActive(false);
                decisionText = "Are you sure you want to quit?";
                break;
            case "Options":
                optionsMenuContainer.SetActive(false);
                decisionText = "Save your choices?";
                break;
            default:
                decisionText = "";
                break;
        }

        returnContainer = decision;
        decisionWindowText.text = decisionText;
    }

    public void Decision()
    {
        switch (returnContainer)
        {
            case "Exit":
                Exit();
                break;
            case "Options":
                ApplyOptions();
                inDecision = false;
                break;
            default:
                Debug.LogError("Error: Check OnClick(); method");
                break;
        }
    }

    public void CloseDecisionWindow()
    {
        switch (returnContainer)
        {
            case "Exit":
                decisionWindow.SetActive(false);
                pauseMenuContainer.SetActive(true);
                break;
            case "Options":
                DiscardOptions();
                inDecision = false;
                break;
            default:
                Debug.LogError("Error: Check OnClick(); method");
                break;
        }

    }

}
