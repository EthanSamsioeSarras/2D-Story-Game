using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuContainer;
    public GameObject optionsMenuContainer;
    private bool isPaused;
    private bool inOptions;

    private void Awake()
    {
        isPaused = false;
        inOptions = false;
        pauseMenuContainer.SetActive(false);
        optionsMenuContainer.SetActive(false);
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

}
