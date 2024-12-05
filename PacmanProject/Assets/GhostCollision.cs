using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollision : MonoBehaviour
{

    private BasicPacManMovement pacManScript;


    // Start is called before the first frame update
    void Start()
    {
        pacManScript = GameObject.FindWithTag("player").GetComponent<BasicPacManMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("player"))
        {
            if (pacManScript.isPoweredUp)
            {
                Debug.Log("Pac-Man ate a ghost!");
                Destroy(transform.parent.gameObject);  // Destroy the parent (ghost)
            }
            else
            {
                Debug.Log("Pac-Man touched a ghost! Lose a life.");
                pacManScript.LoseLife();  // Pac-Man loses a life
            }
        }
    }
}
