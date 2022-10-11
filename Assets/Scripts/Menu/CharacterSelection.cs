using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [Header("Player 1")]
    [SerializeField] GameObject[] dinos;
    int currentDino1 = 0;

    [Header("Player 2")]
    [SerializeField] GameObject[] dinos2;
    int currentDino2 = 0;

    SendDinoIndex dinoMessenger;

    private void Awake()
    {
        currentDino1 = 0;
        for (int i = 1; i < dinos.Length; i++) { dinos[i].SetActive(false); }
        for (int i = 1; i < dinos2.Length; i++) { dinos2[i].SetActive(false); }

        dinoMessenger = GameObject.Find("DontDestroy").GetComponent<SendDinoIndex>();
    }

    public void RightArrowButton()
    {
        if (currentDino1 + 1 < dinos.Length)
        {
            currentDino1++;
            dinos[currentDino1 - 1].SetActive(false);
            dinos[currentDino1].SetActive(true);
        }
        else if (currentDino1 + 1 == dinos.Length)
        {
            currentDino1 = 0;
            dinos[dinos.Length - 1].SetActive(false);
            dinos[currentDino1].SetActive(true);
        }
    }
    public void LeftArrowButton()
    {
        if (currentDino1 - 1 > -1)
        {
            currentDino1--;
            dinos[currentDino1 + 1].SetActive(false);
            dinos[currentDino1].SetActive(true);
        }
        else if (currentDino1 - 1 == -1)
        {
            currentDino1 = dinos.Length - 1;
            dinos[0].SetActive(false);
            dinos[currentDino1].SetActive(true);
        }
    }

    public void RightArrowButton2()
    {
        if (currentDino2 + 1 < dinos2.Length)
        {
            currentDino2++;
            dinos2[currentDino2 - 1].SetActive(false);
            dinos2[currentDino2].SetActive(true);
        }
        else if (currentDino2 + 1 == dinos2.Length)
        {
            currentDino2 = 0;
            dinos2[dinos2.Length - 1].SetActive(false);
            dinos2[currentDino2].SetActive(true);
        }
    }
    public void LeftArrowButton2()
    {
        if (currentDino2 - 1 > -1)
        {
            currentDino2--;
            dinos2[currentDino2 + 1].SetActive(false);
            dinos2[currentDino2].SetActive(true);
        }
        else if (currentDino2 - 1 == -1)
        {
            currentDino2 = dinos2.Length - 1;
            dinos2[0].SetActive(false);
            dinos2[currentDino2].SetActive(true);
        }
    }

    public void StartGame()
    {
        dinoMessenger.player1Dino = currentDino1;
        dinoMessenger.player2Dino = currentDino2;

        SceneManager.LoadScene(1);
    }
}
