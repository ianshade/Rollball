using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int score = 0;
    int hp = 3;
    float startTime;
    int time;
    string HiScorePref = "HiScore";

    public static UnityAction<int> OnHpChanged;
    public static UnityAction<int> OnTimeChanged;
    public static UnityAction<int> OnBestChanged;
    public static UnityAction<int> OnScoreChanged;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startTime = Time.time;
        OnBestChanged?.Invoke(PlayerPrefs.GetInt(HiScorePref, 0));
    }

    void Update()
    {
        var newTime = Mathf.FloorToInt(Time.time - startTime);
        if (time != newTime)
        {
            time = newTime;
            OnTimeChanged?.Invoke(newTime);
        }
    }

    public void CoinPickedUp()
    {
        OnScoreChanged?.Invoke(++score);
    }

    public void ObstacleHit()
    {
        if (--hp == 0)
        {
            PlayerDied();
        }
        OnHpChanged?.Invoke(hp);
    }

    public void DeathHit()
    {
        PlayerDied();
    }

    void PlayerDied()
    {
        if (score > PlayerPrefs.GetInt(HiScorePref, 0))
        {
            PlayerPrefs.SetInt(HiScorePref, score);
        }
        SceneManager.LoadScene(0);
    }

}
