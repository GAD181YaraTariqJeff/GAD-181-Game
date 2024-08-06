using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public PlayerData playerData;
    private static SceneTransitionManager instance;

    void Awake() //added a singleton to ensure there is only on instance on SceneTransitionManager
    {
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
        playerData.playerPosition = playerTransform.position;
        playerData.currentScene = SceneManager.GetActiveScene().name;
    }

    public void LoadPlayerData(GameObject player)
    {
        player.transform.position = playerData.playerPosition;
    }

    public void TransitionToMicrogame(string microgameScene)
    {
        SavePlayerData(GameObject.FindGameObjectWithTag("Player").transform);
        SceneManager.LoadScene(microgameScene);
    }

    public void ReturnToMainGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(playerData.currentScene);
    }
}
