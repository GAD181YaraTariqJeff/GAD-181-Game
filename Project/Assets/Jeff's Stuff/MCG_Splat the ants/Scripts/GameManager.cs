using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AntController antController;
    public UIManager uiManager;
    private int livesNumber = 3;
    private int scoreNumber = 0;
    

    void Start()
    {
        GameObject antObject = GameObject.Find("Ant");
        if (antObject == null)
        {
            Debug.LogError("Ant GameObject not found");
        }
        else
        {
            antController = antObject.GetComponent<AntController>();
            if (antController == null)
            {
                Debug.LogError("AntController component not found on Ant GameObject");
            }
        }

        GameObject uiManagerObject = GameObject.Find("UIManager");
        if (uiManagerObject == null)
        {
            Debug.LogError("UIManager GameObject not found");
        }
        else
        {
            uiManager = uiManagerObject.GetComponent<UIManager>();
            if (uiManager == null)
            {
                Debug.LogError("UIManager component not found on UIManager GameObject");
            }
        }

        // If everything is found, proceed with initialization
        if (antController != null && uiManager != null)
        {
            
            uiManager.UpdateLives(livesNumber);
            uiManager.UpdateScore(scoreNumber);
            ResetAntPosition();
        }
    }

    void Update()
    {
        if (antController != null && antController.transform.position.y < -4.35f)
        {
            if (livesNumber > 0)
            {
                livesNumber--;
                uiManager.UpdateLives(livesNumber);
                ResetAntPosition();
            }
            else
            {
                Destroy(antController.gameObject);
               
            }
        }
    }

    void ResetAntPosition()
    {
        antController.ResetPosition(new Vector3(Random.Range(-2.54f, 2.54f), Random.Range(-4.0f, 3.8f), 0));
    }

    void OnMouseDown()
    {
        scoreNumber++;
        uiManager.UpdateScore(scoreNumber);
        ResetAntPosition();
        antController.walkingSpeed += 0.01f;
    }
}


