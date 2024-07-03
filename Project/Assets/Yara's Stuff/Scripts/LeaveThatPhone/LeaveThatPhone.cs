using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaveThatPhone : MonoBehaviour
{
    [SerializeField] TMP_Text loosingMessage;
    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
      loosingMessage.text = "";  
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true) {
            Debug.Log("Game Over Function called");
            endGame();
        }
    }
    void showLoosingMessage() {
        loosingMessage.text = "You lost!";
        // Debug.Log("The loesing message is displayed");

    }
    public void endGame() {
        destroyAllObjects();
        showLoosingMessage();
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
