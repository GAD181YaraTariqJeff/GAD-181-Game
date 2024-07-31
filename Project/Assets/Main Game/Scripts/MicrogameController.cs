using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameController : MonoBehaviour
{
    private SceneTransitionManager sceneTransitionManager;

    void Start()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            sceneTransitionManager.ReturnToMainGame();
            sceneTransitionManager.LoadPlayerData(player);
        }
    }
}
