using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] Button returnButton;

    bool isPaused = false;

    public void PauseGame(InputAction.CallbackContext context)
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        returnButton.Select();
        isPaused = true;
        Debug.Log("Game Paused");
    }

    public void UnpauseGame(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
