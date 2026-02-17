using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        GameManager.Instance.OnScoreChanged += UpdateUI;
        UpdateUI();
    }

    private void OnDisable()
    {
        GameManager.Instance.OnScoreChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        scoreText.text = $"{GameManager.Instance.PlayerOneScore.ToString()} - {GameManager.Instance.PlayerTwoScore.ToString()}";
    }
}
