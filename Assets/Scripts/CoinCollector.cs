using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the UI text element displaying the score
    private int score = 0; // Player's score

    private void Start()
    {
        UpdateScoreUI(); // Set the initial score on game start
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject);
        }
    }

    private void CollectCoin(GameObject coin)
    {
        Destroy(coin); // Remove the collected coin from the scene
        score += 10; // Increase the score by 10 (you can adjust this value)
        UpdateScoreUI(); // Update the UI text to display the new score
    }

    private void UpdateScoreUI()
    {
        // Update the UI text to display the current score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}