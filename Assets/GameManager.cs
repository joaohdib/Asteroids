using System.Xml.Serialization;
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
        ResetScore();
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;

    }

    private void ResetScore()
    {
        
        score = 0;
        scoreText.text = "0";

    }

    public void QuitGame()
    {
        Application.Quit();
    }


    private void DestroyAllAsteroids()
    {

        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        foreach (GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
        }

    }

}