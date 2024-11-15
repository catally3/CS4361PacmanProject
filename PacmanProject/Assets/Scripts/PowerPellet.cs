
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPellet : MonoBehaviour
{
    public int scoreValue = 50; // Higher score value for each power pellet
    public float powerDuration = 10f; // Duration of power mode in seconds

    private void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.CompareTag("pacman")) { 
            // Add score to the game manager
            GameManager.instance.AddScore(scoreValue);

            // Activate power mode for Pac-Man, allowing him to eat ghosts
            GameManager.instance.ActivatePowerMode(powerDuration);

            // Destroy the power pellet
            Destroy(this.gameObject);
        }
    }
}
