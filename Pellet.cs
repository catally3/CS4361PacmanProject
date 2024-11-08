
// Pellet portion of Pacman
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int scoreValue = 10; // Score value for each pellet

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pacman"))
        {
            // Add score to the game manager
            GameManager.instance.AddScore(scoreValue);
            // Destroy the pellet
            Destroy(gameObject);
        }
    }
}
