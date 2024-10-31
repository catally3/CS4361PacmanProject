using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour{
    private const Vector3 up = Vector3.forward;
    private const Vector3 down = Vector3.back;
    private const Vector3 left = Vector3.left;
    private const Vector3 right = Vector3.right;
    public const int totalPellets = 20;        // Fill in when the board is done      

    
    public int remainingLives;          // If remainingLives is 0, game over
    public int remainingPellets;        // When remainingPellets is 0, game over
    public bool isPoweredUp;            // If isPoweredUp is true PacMan can eat ghosts
    public bool canMoveForward;         
    public Vector3 currentDirection;    // PacMan constantly moves forward in this direction
    public Vector3 nextDirection;       // Holds a movement direction from user input, waits for it to be valid
    
    private void MoveToStart(){
        // Fill in when board is finished
        int xStartPosition = 0;
        int yStartPosition = 0;
        int zStartPosition = 0;
        
        transform.position = new Vector3(xStartPosition, yStartPosition, zStartPosition);
    }
    
    // Initialize PacMan on game start or aftern death
    private void InitializePacMan(){
        MoveToStart();
        currentDirection = up;
        SetDirection(currentDirection);
        isPoweredUp = false;
        canMoveForward = true;
    }

    public void CollectPellet(){
        remainingPellets--;
    }
    
    // Thread: 10 second power up timer
    private IEnumerator PowerUpTimer(){
        isPoweredUp = true;
        yield return new WaitForSeconds(10); 
        isPoweredUp = false;
    }

    // Call when PacMan collides with a power pellet
    public void PowerUp(){
        StartCoroutine(PowerUpTimer());
    }

    private void SetCurrentDirection(Vector3 direction){
        currentDirection = direction;
        transform.LookAt(transform.position + currentDirection);
    }

    private void SetNextDirection(Vector3 direction){
        nextDirection = direction;
    }

    // If there is no wall blocking PacMan from changing direction to nextDirection return true
    private bool CanChangeDirection(){
        float raycastDistance = 5F;
        LayerMask wallMask = LayerMask.GetMask("wall");

        if(Physics.Raycast(transform.position, nextDirection, raycastDistance, wallMask))
            return false;
        
        return true;    
    }

    // Collision Events
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "wall"){
            canMoveForward = false;
        } else if(collision.gameObject.tag == "pellet"){
            CollectPellet();
        } else if(collision.gameObject.tag == "power_pellet"){
            CollectPellet();
            PowerUp();
        } else if(collision.gameObject.tag == "ghost" && !isPoweredUp){
            remainingLives--;
            InitializePacMan();
        }
    }

    // Start is called before the first frame update
    void Start(){
        remainingLives = 3;
        remainingPellets = totalPellets;
        InitializePacMan();
    }

    // Update is called once per frame
    void Update(){
        float movementSpeed = 3.0f;

        if(currentDirection != nextDirection && CanChangeDirection()){
            SetCurrentDirection(nextDirection);
            canMoveForward = true;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            SetNextDirection(up);
        } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            SetNextDirection(left);
        } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            SetNextDirection(down);
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            SetNextDirection(right);
        }
        
        if(canMoveForward == true) {
            transform.position += currentDirection * Time.deltaTime * movementSpeed;
        }
    }
}
