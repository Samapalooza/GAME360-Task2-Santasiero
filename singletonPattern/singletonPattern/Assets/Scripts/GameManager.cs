
using UnityEngine;
using UnityEngine.UI;
using TMPro; //Namespace for textmeshpro
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    [Header("Game Stats")]
    public int score = 0;
    public int lives = 3;
    public int enemiesKilled = 0;

    [Header("UI References")]
    public Text scoreText;
    public Text livesText;
    public Text enemiesKilledText;
    public GameObject gameEndPanel;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManagers
        }
    }

    private void Start()
    {
        UpdateUI();
    }

 private void HideGameOverPanel()
 {
     if (gameEndPanel)
     {
         gameEndPanel.SetActive(false);
     }
 }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log($"Score increased by {points}. Total: {score}");
        UpdateUI();
     }

    public void LoseLife()
    {
        lives--;
        Debug.Log($"Life lost! Lives remaining: {lives}");
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        AddScore(100); // 100 points per enemy
        Debug.Log($"Enemy killed! Total enemies defeated: {enemiesKilled}");
    }

    public void CollectiblePickedUp(int value)
    {
        AddScore(value);
        Debug.Log($"Collectible picked up worth {value} points!");
    }

    private void UpdateUI()
    {
        if (scoreText) scoreText.text = "Score: " + score;
        if (livesText) livesText.text = "Lives: " + lives;
        if (enemiesKilledText) enemiesKilledText.text = "Enemies: " + enemiesKilled;
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER!");
        if (gameEndPanel) gameEndPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void reloadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene2 Singleton");
        gameEndPanel.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        score = 0;
        lives = 3;
        enemiesKilled = 0;
        Time.timeScale = 1f;
        if (gameEndPanel) gameEndPanel.SetActive(false);
        UpdateUI();
    }
}
