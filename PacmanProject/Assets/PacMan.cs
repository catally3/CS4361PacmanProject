using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    const int totalPellets;             // Fill this in when board is finished


    public int remainingLives;          // If remainingLives is 0, game over
    public int remainingPellets;        // When remainingPellets is 0, game over
    public bool isPoweredUp;            // If isPoweredUp is true PacMan can eat ghosts
    public Vector3 currentDirection;
    

    private static void MoveToStart(){
        // Set these values to starting position, when board is finished
        const int xStartPosition;
        const int yStartPosition;
        const int zStartPosition;
        
        transform.position = new Vector3(xStartPosition, yStartPosition, zStartPosition);
    }
    
    private static void SetDirection(int zDirection){
        currentDirection = new Vector3(transform.position.x, transform.position.y, zDirection);
        transform.position = currentDirection;
    }

    // Initialize PacMan on game start
    private static void InitializePacMan(){
        remainingLives = 3;
        remainingPellets = totalPellets;
        isPowered = false;
        MoveToStart();
        SetDirection(0);
    }

    // Call when PacMan collides with a ghost and isPoweredUp is false 
    public void ResetPacMan(){
        remainingLives--;
        isPowered = false;
        MoveToStart();
        SetDirection(0);
    }
    
    // Call when PacMan collides with a wall
    public void ReverseDirection(){

    }

    // Call when PacMan collides with a pellet
    public void CollectPellet(){
        remainingPellets--;
    }

    // Call when PacMan collides with a power pellet
    public void PowerUp(){
        isPoweredUp = true;
        // start timer

        // finish timer
        isPoweredUp = false;
    }
    
    // Start is called before the first frame update
    void Start(){
        InitializePacMan();
    }

    // Update is called once per frame
    void Update(){
        // Update currentDirection when a movement key is pressed
        // Move forward continuously
    }
}
