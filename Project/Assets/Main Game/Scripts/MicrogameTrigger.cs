using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MicrogameTrigger : MonoBehaviour
{
    public string[] microgameScenes;
    private SceneTransitionManager sceneTransitionManager;

    void Start()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int randomIndex = Random.Range(0, microgameScenes.Length);
            string selectedMicrogame = microgameScenes[randomIndex];
            sceneTransitionManager.TransitionToMicrogame(selectedMicrogame);
        }
    }
}
