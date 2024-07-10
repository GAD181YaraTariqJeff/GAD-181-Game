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

    void Start()
    {
        Spawn();
    }


    void Update()
    {
        gameTime -= Time.deltaTime;
        if(gameTime < 1)
        {
            gameTime = 0;
            Time.timeScale = 0f;
            Debug.Log("Game over!");
        }
        gameText.text = gameTime.ToString();


    }

    public void Spawn()
    {
        GameObject mole = Instantiate(molePrefab) as GameObject;
        mole.transform.position = spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position;
    }
}
