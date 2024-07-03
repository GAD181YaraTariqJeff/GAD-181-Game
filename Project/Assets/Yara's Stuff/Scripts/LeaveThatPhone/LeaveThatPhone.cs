using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaveThatPhone : MonoBehaviour
{
    [SerializeField] TMP_Text EndGameMessage;
    public static int numberOfCharacters = 3;
    public enum GameState {
        playing,
        win,
        loose
    }
    public static GameState gameState = GameState.playing;

    // Start is called before the first frame update
    void Start()
    {
      EndGameMessage.text = "";  
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.loose) {
            //Debug.Log("Game Over Function called");
            EndGameMessage.text = "You lost!";
            //destroyAllObjects();
        }
        else if(gameState == GameState.win) {
            EndGameMessage.text = "You Won!";
            //destroyAllObjects();
        }
    }
    

    public void destroyAllObjects() {
        GameObject[] allCharacterObjects = GameObject.FindGameObjectsWithTag("Character"); 
        GameObject train = GameObject.FindGameObjectWithTag("Train");
        foreach (GameObject o in allCharacterObjects) {
			Destroy(o);
		}
        Destroy(train);
    }
}
