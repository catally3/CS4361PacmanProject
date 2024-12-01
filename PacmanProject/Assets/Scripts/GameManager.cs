using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPowerModeActive = false;
    public float powerModeEndTime;
    private int score;
    private Text scoreText;

    public void Start()
    {
        scoreText = GetComponent<Text>();
        score = 0;
    }

    private void Awake()
    {
        // Ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
        }
        else
        {
            Debug.LogWarning("Duplicate GameManager detected and destroyed.");
            Destroy(gameObject);
        }
    }

    public void AddScore(int value) {
        this.score += value;
        scoreText.text = "Score: " + this.score;
    }
    public void ActivatePowerMode(float duration)
    {
        isPowerModeActive = true;
        powerModeEndTime = Time.time + duration;

        // Set ghosts to frightened mode
        foreach (Ghost ghost in FindObjectsOfType<Ghost>())
        {
            ghost.SetFrightenedMode(true);
        }

        // Start coroutine to disable power mode after duration
        StartCoroutine(EndPowerModeAfterDelay(duration));
    }

    private IEnumerator EndPowerModeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isPowerModeActive = false;

        // Set ghosts back to normal mode
        foreach (Ghost ghost in FindObjectsOfType<Ghost>())
        {
            ghost.SetFrightenedMode(false);
        }
    }
}
