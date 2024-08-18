using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawningMoles : MonoBehaviour
{
    public GameObject molePrefab;
    public Transform[] spawnpoints;
    public float gameTime;
    public Text gameText;
    public GameObject guideUI; // Reference to the guide UI
    public float guideDuration = 3f; // Duration to show the guide

    void Start()
    {
        StartCoroutine(DisplayGuideAndStartGame());
    }


    void Update()
    {
        if (Time.timeScale == 1f) // Only update if the game is running
        {
            gameTime -= Time.deltaTime;
            if (gameTime < 1)
            {
                gameTime = 0;
                Time.timeScale = 0f;
                Debug.Log("Game over!");
            }
            gameText.text = gameTime.ToString();
        }
    }

    public void Spawn()
    {
        GameObject mole = Instantiate(molePrefab) as GameObject;
        mole.transform.position = spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position;
    }
    IEnumerator DisplayGuideAndStartGame()
    {
        guideUI.SetActive(true); // Show the guide UI
        yield return new WaitForSeconds(guideDuration); // Wait for the guide duration
        guideUI.SetActive(false); // Hide the guide UI
        Time.timeScale = 1f; // Start the game
        Spawn(); // Start spawning moles
    }
}
