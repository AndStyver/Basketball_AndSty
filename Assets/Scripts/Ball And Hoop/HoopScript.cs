using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoopScript : MonoBehaviour
{
    public int score;
    [SerializeField] TextMeshProUGUI scoreText;

    AudioSource audSource;

    private void Awake()
    {
        UpdateScoreText();
        audSource = GetComponent<AudioSource>();
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void PlaySound()
    {
        audSource.Play();
    }
}
