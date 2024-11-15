public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPowerModeActive = false;
    public float powerModeEndTime;

    private void Awake()
    {
        instance = this;
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
