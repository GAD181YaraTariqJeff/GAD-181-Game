using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopThemBalloons : MonoBehaviour
{
    [SerializeField] TMP_Text loosingMessage;
    [SerializeField] GameObject normalBalloons;
    [SerializeField] GameObject bombBalloons;

    public static GameObject balloonToRespawn;
    public static bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        loosingMessage.text = "";
        SpawnBalloons();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height*.9f));
        Vector2 min = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Debug.Log(max);
        Debug.DrawLine(min,max);
        if (gameOver == true)
        {
            endGame();
        }
    }

    public void endGame()
    {
        destroyAllBalloons();
        showLoosingMessage();
    }

    void destroyAllBalloons()
    {
        Debug.Log("Game Object Clicked: " + gameObject.name);
        GameObject[] allBalloonsObjects = GameObject.FindGameObjectsWithTag("Balloon");
        foreach (GameObject o in allBalloonsObjects)
        {
            Destroy(o);
        }
    }
    void showLoosingMessage()
    {
        loosingMessage.text = "You lost!";
        // Debug.Log("The loesing message is displayed");

    }

    void SpawnBalloons()
    {


        for (int i = 0; i < 4; i++)
        {
            Vector2 position = FindPosition();
            while (Physics2D.OverlapCircle(transform.position, 2f))
            {
                position = FindPosition();
            }

            Instantiate(normalBalloons, position, Quaternion.identity);
        }
        for (int i = 0; i < 4; i++)
        {
            Vector2 position = FindPosition();
            while (Physics2D.OverlapCircle(transform.position, 2f))
            {
                position = FindPosition();
            }

            Instantiate(bombBalloons, position, Quaternion.identity);
        }

    }
    Vector2 FindPosition()
    {

        Vector2 max = Camera.main.ScreenToWorldPoint
                            (new Vector2(Screen.width, Screen.height));
        Vector2 min = Camera.main.ScreenToWorldPoint
                            (new Vector2(0, 0));
        float Xoffset = 0.3f;
        float Yoffset = 0.3f;
        float xPos = Random.Range(min.x + Xoffset, max.x - Xoffset);
        float yPos = Random.Range(min.y + Yoffset, max.y - Yoffset - 5f);
        return new Vector2(xPos, yPos);
    }
    private void OnDrawGizmos()
    {

    }
}
