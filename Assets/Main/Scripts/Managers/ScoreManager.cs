using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private int score;
    public Text scoreText;
    public Text endLevelScoreText;

    public static Action<int> SetScoreText;

    public int Score { get { return score;} set { if(value < 0 && score <= 0) score = 0; else score += value; } }


    private void Awake()
    {
        if (instance == null)
            instance = this;

        score = 0;
        scoreText.text = score.ToString();
    }

    private void UpdateScore(int value)
    {
        Score = value;
        scoreText.text = (score * 5).ToString();
        endLevelScoreText.text = "You Gained " + (score * 5).ToString() + " Dollar";
    }

    private void OnEnable()
    {
        PStackTrigger.OnDollerPicked += UpdateScore;
    }

    private void OnDisable()
    {
        PStackTrigger.OnDollerPicked -= UpdateScore;
    }
}