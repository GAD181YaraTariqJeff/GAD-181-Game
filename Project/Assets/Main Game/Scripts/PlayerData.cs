using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 0)]
public class PlayerData : ScriptableObject
{
    public Vector3 playerPosition;
    public string currentScene;
    public Vector3 startingPosition;
    public int _microgameScore; 
    private void OnEnable() 
    {
        _microgameScore = 0; // Initialize score
        // Initialize the starting position if not already set
        if (startingPosition == Vector3.zero)
        {
            startingPosition = new Vector3(-10.5f, -3.05f, 0f);
        }
        playerPosition = startingPosition; // Ensure player starts at this position
    }
    public void SavePosition(Transform playerTransform)
    {
        playerPosition = playerTransform.position;
        currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name; // Save the current scene as well
    }
}
