using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AntController ant;
    public UIManager uiManager;
    private int livesNumber = 3;
    private int scoreNumber = 0;
    

    void Start()
    {
        ant = GameObject.Find("Ant").GetComponent<AntController>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
     

        uiManager.UpdateLives(livesNumber);
        uiManager.UpdateScore(scoreNumber);

        ResetAntPosition();
    }


    void Update()
    {
        if (ant.transform.position.y < -4.35f)
        {
            if (livesNumber > 0)
            {
                livesNumber--;
                uiManager.UpdateLives(livesNumber);
                ResetAntPosition();
            }
            else
            {
                Destroy(ant.gameObject);
                
            }
        }

    }
    void ResetAntPosition()
    {
        ant.ResetPosition(new Vector3(Random.Range(-2.54f, 2.54f), Random.Range(-4.0f, 3.8f), 0));
    }
    void OnMouseDown()
    {
        scoreNumber++;
        uiManager.UpdateScore(scoreNumber);
        ResetAntPosition();
        ant.walkingSpeed += 0.01f;
    }
}
