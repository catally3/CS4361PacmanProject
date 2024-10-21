using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : MonoBehaviour
{
    public int remainingLives;
    
    public bool isPowered;

    static void MoveToStart(){
        const int xStartPosition;
        const int yStartPosition;
        const int zStartPosition;
        
        transform.position = new Vector3(xStartPosition, yStartPosition, zStartPosition);
    }

    static void SetDirection(int zDirection){
        transform.position = new Vector3(transform.position.x, transform.position.y, zDirection);
    }

    // Initialize PacMan on game start
    static void InitializePacMan(){
        remainingLives = 3;
        isPowered = false;
        MoveToStart();
        SetDirection(0);
    }

    // Reset PacMan on death    
    static void ResetPacMan(){
        remainingLives--;
        isPowered = false;
        MoveToStart();
        SetDirection(0);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
