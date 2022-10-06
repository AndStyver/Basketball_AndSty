using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject[] dinos;
    int currentDino = 0;

    private void Awake()
    {
        currentDino = 0;
        for (int i = 1; i < dinos.Length; i++)
        {
            dinos[i].SetActive(false);
        }
    }

    public void RightArrowButton()
    {
        if (currentDino + 1 < dinos.Length)
        {
            currentDino++;
            dinos[currentDino - 1].SetActive(false);
            dinos[currentDino].SetActive(true);
        }
        else if (currentDino + 1 == dinos.Length)
        {
            currentDino = 0;
            dinos[dinos.Length - 1].SetActive(false);
            dinos[currentDino].SetActive(true);
        }
    }
    public void LeftArrowButton()
    {
        if (currentDino - 1 > -1)
        {
            currentDino--;
            dinos[currentDino + 1].SetActive(false);
            dinos[currentDino].SetActive(true);
        }
        else if (currentDino - 1 == -1)
        {
            currentDino = dinos.Length - 1;
            dinos[0].SetActive(false);
            dinos[currentDino].SetActive(true);
        }
    }

}
