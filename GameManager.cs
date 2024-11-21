using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isPowerModeActive = false;
    public float powerModeEndTime;

    private void Awake()
    {
        // Ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
        }
        else
        {
            Debug.LogWarning("Duplicate GameManager detected and destroyed.");
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Activates power mode for a given duration and sets ghosts to frightened mode.
    /// </summary>
    /// <param name="duration">Duration of the power mode in seconds.</param>
    public void ActivatePowerMode(float duration)
    {
        if (isPowerModeActive)
        {
            Debug.Log("Power mode is already active. Extending its duration.");
            powerModeEndTime = Time.time + duration; // Extend power mode
            return;
        }

        isPowerModeActive = true;
        powerModeEndTime = Time.time + duration;

        // Set ghosts to frightened mode
        foreach (Ghost ghost in FindObjectsOfType<Ghost>())
        {
            ghost.SetFrightenedMode(true);
        }

        // Start coroutine to disable power mode after the specified duration
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

    /// <summary>
    /// Adds score to the player's total.
    /// </summary>
    /// <param name="score">The score value to add.</param>
    public void AddScore(int score)
    {
        // Placeholder: Implement scoring logic
        Debug.Log($"Score added: {score}");
    }
}
