using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
            DisablePlayerScript();
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
        EnablePlayerScripts();
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Debug.Log("Game Unpaused");
    }

    public void ResetGame()
    {
        EnablePlayerScripts();

        for (int i = 0; i < hoops.Length; i++) { hoops[i].score = 0; }

        ball.transform.position = Vector3.zero;
        ball.ResetVelocity();

        players[0].transform.position = new(-4, -2);
        players[1].transform.position = new(4, -2);

        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }

    void EnablePlayerScripts()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.GetComponent<PlayerInput>().enabled = true;
        }
    }

    void DisablePlayerScript()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.GetComponent<PlayerInput>().enabled = false;
        }
    }
}
