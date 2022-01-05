using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private const string High_Score = "High Score";
    void Awake()
    {
        _MakeSingleInstance();
        IsGameStartForTheFirstTime();
    }

    void IsGameStartForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartForTheFirstTime"))
        {
            PlayerPrefs.SetInt(High_Score, 0);
            PlayerPrefs.SetInt("IsGameStartForTheFirstTime", 0);
        }


    }

    void _MakeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(High_Score, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(High_Score);
    }
}
