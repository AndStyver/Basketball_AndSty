using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuHandler : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject creditsPanel;
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject charSelectPanel;

    [Header("Buttons")]
    [SerializeField] Button startButton;
    [SerializeField] Button backButton;

    [SerializeField] AudioSource soundEffect;

    private void Awake()
    {
        creditsPanel.SetActive(false);
        tutorialPanel.SetActive(false);
        charSelectPanel.SetActive(false);
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ButtonCredits()
    {
        PlaySound();
        creditsPanel.SetActive(!creditsPanel.activeSelf);
        if (tutorialPanel.activeSelf == true) { tutorialPanel.SetActive(false); }
        if (settingsPanel.activeSelf == true) { settingsPanel.SetActive(false); }
    }

    public void ButtonTutorial()
    {
        PlaySound();
        tutorialPanel.SetActive(!tutorialPanel.activeSelf);
        if (creditsPanel.activeSelf == true) { creditsPanel.SetActive(false); }
        if (settingsPanel.activeSelf == true) { settingsPanel.SetActive(false); }
    }

    public void ButtonSettings()
    {
        PlaySound();
        settingsPanel.SetActive(!settingsPanel.activeSelf);
        if (creditsPanel.activeSelf == true) { creditsPanel.SetActive(false); }
        if (tutorialPanel.activeSelf == true) { tutorialPanel.SetActive(false); }
    }

    public void ButtonStart()
    {
        PlaySound();
        mainMenuPanel.SetActive(false);
        charSelectPanel.SetActive(true);
        backButton.Select();
    }

    public void ButtonBack()
    {
        PlaySound();
        charSelectPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        startButton.Select();
    }

    public void PlaySound()
    {
        soundEffect.Play();
    }
}
