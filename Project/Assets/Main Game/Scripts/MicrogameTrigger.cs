using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicrogameTrigger : MonoBehaviour
{
    public string[] microgameScenes;
    private SceneTransitionManager sceneTransitionManager;
    public MainPlayerScript mainPlayerScript;//Reference to the main player script
    public PlayerData playerData;  // Reference to the PlayerData ScriptableObject
    private bool isPlayerInRange = false;

    void Start()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    void Update()
    {
        // Check if the player is in range and presses the "E" key
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            //Update the score counter
            mainPlayerScript.IncrementMicrogameScore();
            // Save the player's position at the arcade machine's position
            playerData.playerPosition = transform.position;

            // Select a random microgame scene
            int randomIndex = Random.Range(0, microgameScenes.Length);
            string selectedMicrogame = microgameScenes[randomIndex];

            // Transition to the selected microgame
            sceneTransitionManager.TransitionToMicrogame(selectedMicrogame);

            // Destroy the arcade machine after interaction
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            
        }
    }
}
