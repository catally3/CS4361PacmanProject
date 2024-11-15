
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int scoreValue = 10; // Score value for each pellet

    private void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.CompareTag("pacman"))
        {
            // Add score to the game manager
            GameManager.instance.AddScore(scoreValue);
            // Destroy the pellet
            Destroy(this.gameObject);
        }
    }
}
