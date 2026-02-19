using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int PlayerOneScore { get; private set; }
    public int PlayerTwoScore { get; private set; }
    public int WinningScore = 10;

    public event Action OnScoreChanged;
    public event Action OnGameOver;
    public event Action OnRoundReset;
    public event Action OnReplay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int playerIndex)
    {
        if (playerIndex == 1)
        {
            PlayerOneScore++;
        }
        else
        {
            PlayerTwoScore++;
        }

        OnScoreChanged?.Invoke();

        if(PlayerOneScore >= WinningScore || PlayerTwoScore >= WinningScore)
        {
            GameOver();
        }
        else
        {
            OnRoundReset?.Invoke();
        }
    }

    public void ResetScores()
    {
        PlayerOneScore = 0;
        PlayerTwoScore = 0;
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void Replay()
    {
        ResetScores();
        OnScoreChanged?.Invoke();
        OnReplay?.Invoke();
    }
}
