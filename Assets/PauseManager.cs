using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] Button returnButton;

    [SerializeField] HoopScript[] hoops;
    [SerializeField] BallPhysics ball;
    [SerializeField] GameObject[] players;

    bool isPaused = false;
    public void PauseGame(InputAction.CallbackContext context)
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            returnButton.Select();
            isPaused = true;
            Debug.Log("Game Paused");
        }
        else if (isPaused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
            Debug.Log("Game Unpaused");
        }
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Game Unpaused");
    }

    public void ResetGame()
    {
        for (int i = 0; i < hoops.Length; i++) { hoops[i].score = 0; }

        ball.transform.position = Vector3.zero;
        ball.ResetVelocity();

        players[0].transform.position = new(-4, -2);
        players[1].transform.position = new(4, -2);

        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
