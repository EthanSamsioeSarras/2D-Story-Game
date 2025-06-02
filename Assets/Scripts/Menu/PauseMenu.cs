using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuContainer;
    public GameObject optionsMenuContainer;
    public GameObject controlsMenuContainer;
    private bool isPaused;
    private bool inOptions;
    private bool inControls;

    private void Awake()
    {
        isPaused = false;
        inOptions = false;
        inControls = false;
        pauseMenuContainer.SetActive(false);
        optionsMenuContainer.SetActive(false);
        controlsMenuContainer.SetActive(false);
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
    }

}
