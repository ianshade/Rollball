using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI lifesText;
    [SerializeField]
    TextMeshProUGUI bestText;
    [SerializeField]
    TextMeshProUGUI timeText;

    void Awake()
    {
        GameManager.OnHpChanged += OnHpChanged;
        GameManager.OnTimeChanged += OnTimeChanged;
        GameManager.OnBestChanged += OnBestChanged;
        GameManager.OnScoreChanged += OnScoreChanged;
    }

    void OnHpChanged(int hp)
    {
        lifesText.text = "Lifes: " + hp;
    }

    void OnTimeChanged(int time)
    {
        timeText.text = time.ToString();
    }

    void OnBestChanged(int best)
    {
        bestText.text = "Best: " + best;
    }

    void OnScoreChanged(int score)
    {
        scoreText.text = "Score: " + score;
    }

    void OnDestroy()
    {
        GameManager.OnHpChanged -= OnHpChanged;
        GameManager.OnTimeChanged -= OnTimeChanged;
        GameManager.OnBestChanged -= OnBestChanged;
        GameManager.OnScoreChanged -= OnScoreChanged;
    }
}
