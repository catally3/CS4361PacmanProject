using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPowerModeActive = false;
    public float powerModeEndTime;
    private int score;
    private TMPro.TMP_Text scoreText;

    public void Start()
    {
        scoreText = GetComponent<TMPro.TMP_Text>();
        score = 0;
        AddScore(0);
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

    public void gameWin() {
        SceneManager.LoadScene("Win");
    }

    public void gameOver() {
        SceneManager.LoadScene("GameOver");
    }

    public void AddScore(int value) {
        this.score += value;
        scoreText.SetText("Score: " + this.score);
    }
}
