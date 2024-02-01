using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hoverSpeed = 2f; // Speed of hovering
    public int health = 3; // Initial health of the enemy

    void Update()
    {
        // Move the enemy up and down to simulate hovering
        transform.Translate(Vector2.up * Mathf.Sin(Time.time * hoverSpeed) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy collides with the player
        if (other.CompareTag("Player"))
        {
            // Call a function to handle player death (you can replace this with your own logic)
            PlayerDeath();
        }

        // Check if the enemy collides with a bullet
        if (other.CompareTag("Bullet"))
        {
            // Call a function to handle enemy destruction
            BulletHit();
        }
    }

    void PlayerDeath()
    {
        // Replace this with your own logic for player death
        Debug.Log("Player died!");
        // For example, you might want to reload the level or show a game over screen
    }

    void BulletHit()
    {
       
            DestroyEnemy();
        
    }

    void DestroyEnemy()
    {
        // Replace this with your own logic for enemy destruction
        Debug.Log("Enemy destroyed!");
        // For example, you might want to play an explosion animation and remove the GameObject
        Destroy(gameObject);
    }
}