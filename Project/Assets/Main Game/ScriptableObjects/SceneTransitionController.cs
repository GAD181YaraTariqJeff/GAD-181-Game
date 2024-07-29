using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneTransitionController : MonoBehaviour
{
    public SceneData currentScene;
    public SceneData nextScene;

    public void SwitchToNextScene()
    {
        if (nextScene != null)
        {
            SceneManager.LoadScene(nextScene.sceneName);
        }
    }
}
