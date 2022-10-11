using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoopScript : MonoBehaviour
{
    public int score;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake() { UpdateScoreText(); }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
