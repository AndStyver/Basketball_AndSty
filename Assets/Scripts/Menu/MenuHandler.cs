using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuHandler : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject charSelectPanel;

    [Header("Buttons")]
    [SerializeField] Button startButton;
    [SerializeField] Button backButton;

    private void Awake()
    {
        creditsPanel.SetActive(false);
        charSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ButtonCredits()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }

    public void ButtonStart()
    {
        mainMenuPanel.SetActive(false);
        charSelectPanel.SetActive(true);
        backButton.Select();
    }

    public void ButtonBack()
    {
        charSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        startButton.Select();
    }
}
