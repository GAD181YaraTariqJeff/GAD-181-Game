using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public PlayerData playerData;
    private static SceneTransitionManager instance;

    void Awake()
    {
        // Singleton pattern to ensure only one instance of SceneTransitionManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerData(Transform playerTransform)
    {
        // Save the player's position and the current scene
        playerData.playerPosition = playerTransform.position;
        playerData.currentScene = SceneManager.GetActiveScene().name;
    }

    public void LoadPlayerData(GameObject player)
    {
        // Set the player's position based on saved data
        player.transform.position = playerData.playerPosition;
    }

    public void TransitionToMicrogame(string microgameScene)
    {
        // Save the player's data only if it hasn't been saved already
        if (playerData.currentScene != microgameScene)
        {
            SavePlayerData(GameObject.FindGameObjectWithTag("Player").transform);
        }
        SceneManager.LoadScene(microgameScene);
    }

    public void ReturnToMainGame()
    {
        // Load the main game scene and restore player's saved position
        Time.timeScale = 1;
        SceneManager.LoadScene(playerData.currentScene);
    }
}
