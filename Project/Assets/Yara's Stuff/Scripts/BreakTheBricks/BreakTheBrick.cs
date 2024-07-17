using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreakTheBrick : MonoBehaviour
{
    public static int numberOfBricks = 6;
    public static bool ballIsAtBottomEdge = false;
    [SerializeField] TMP_Text EndGameMessage;
    
    // Start is called before the first frame update
    void Start()
    {
        EndGameMessage.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if((numberOfBricks == 0) ||  ballIsAtBottomEdge) {
            GameObject Ball = GameObject.FindGameObjectWithTag("Ball");
            GameObject Paddle = GameObject.FindGameObjectWithTag("Paddle");
            Destroy(Ball);
            Destroy(Paddle);
        }
        if(numberOfBricks == 0) {
            EndGameMessage.text = "you won!!";
        }
        if(ballIsAtBottomEdge) {
            EndGameMessage.text = "you lost!!";
        }
    }
}
