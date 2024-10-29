using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    public int totalPellets;        // Fill in when the board is done      

    // Constant variables for storing rotation directions for PacMan
    private readonly Vector3 up = Vector3.forward;
    private readonly Vector3 down = Vector3.back;
    private readonly Vector3 left = Vector3.left;
    private readonly Vector3 right = Vector3.right;

    public int remainingLives;          // If remainingLives is 0, game over
    public int remainingPellets;        // When remainingPellets is 0, game over
    public bool isPoweredUp;            // If isPoweredUp is true PacMan can eat ghosts
    public Vector3 currentDirection;    // PacMan constantly moves forward in this direction
    public Vector3 nextDirection;       // Holds a movement direction from user input, waits for it to be valid
    
    private void MoveToStart(){
        // Fill in when board is finished
        int xStartPosition = 0;
        int yStartPosition = 0;
        int zStartPosition = 0;
        
        transform.position = new Vector3(xStartPosition, yStartPosition, zStartPosition);
    }
    
    private void SetDirection(Vector3 direction){
        transform.LookAt(transform.position + direction);
    }

    // Initialize PacMan on game start
    private void InitializePacMan(){
        remainingLives = 3;
        remainingPellets = totalPellets;
        isPoweredUp = false;
        MoveToStart();
        currentDirection = up;
        SetDirection(currentDirection);
    }

    // Call when PacMan collides with a ghost and isPoweredUp is false 
    public void ResetPacMan(){
        remainingLives--;
        isPoweredUp = false;
        MoveToStart();
        currentDirection = up; 
        SetDirection(currentDirection);
    }

    // Call when PacMan collides with a pellet
    public void CollectPellet(){
        remainingPellets--;
    }
    
    // Thread for 10 second power up timer
    private IEnumerator PowerUpTimer() {
        isPoweredUp = true;
        yield return new WaitForSeconds(10); 
        isPoweredUp = false;
    }

    // Call when PacMan collides with a power pellet
    public void PowerUp(){
        StartCoroutine(PowerUpTimer());
    }
    
    // Start is called before the first frame update
    void Start(){
        InitializePacMan();
    }

    // If there is no wall blocking PacMan from changing direction to nextDirection return true
    private bool CanChangeDirection(){
        // Detect walls in the direction for nextDirection
        return false;    
    }

    // Update is called once per frame
    void Update(){
        float movementSpeed = 3.0f;

        if(currentDirection != nextDirection && CanChangeDirection()){
            currentDirection = nextDirection;
            SetDirection(currentDirection);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            nextDirection = up;
        } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            nextDirection = left;
        } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            nextDirection = down;
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            nextDirection = right;
        }
            
        transform.position += currentDirection * Time.deltaTime * movementSpeed;
    }
}
