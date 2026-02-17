using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        GameManager.Instance.OnGameOver += ShowPanel;
        gameOverPanel.SetActive(false);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= ShowPanel;
    }

    private void ShowPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
