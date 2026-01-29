using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private PlayerScript playerScript;

    public static GameManager Instance { get; private set; }
    public int score = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = "Your score: " + score.ToString();
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {

        playerScript.RestartPlayer();
        DestroyAllAsteroids();
    }

    private void DestroyAllAsteroids()
    {
        
    }

}