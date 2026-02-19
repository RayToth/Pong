using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        GameManager.Instance.OnGameOver += ShowPanel;
        GameManager.Instance.OnReplay += HidePanel;
        gameOverPanel.SetActive(false);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= ShowPanel;
        GameManager.Instance.OnReplay -= HidePanel;
    }

    private void ShowPanel()
    {
        gameOverPanel.SetActive(true);
    }

    private void HidePanel()
    {
        gameOverPanel.SetActive(false);
    }
}
