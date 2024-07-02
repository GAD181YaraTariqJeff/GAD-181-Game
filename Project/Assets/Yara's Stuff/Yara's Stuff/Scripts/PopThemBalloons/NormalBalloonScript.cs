using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class NormalBalloonScript : MonoBehaviour
{
    // Start is called before the first frame update
     async void Awake()
    {
   
                //GetComponent<Collider2D>().enabled=true;

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the normal balloons, it makes them disappear
    /// </summary>
    void OnMouseDown()
    {
        Debug.Log("Game Object Clicked: " + gameObject.name);
        Destroy(gameObject);
    }
   
    void changeTheBalloonsLocation()
    {
        Vector2 max = Camera.main.ScreenToWorldPoint
                            (new Vector2(Screen.width, Screen.height));
        Vector2 min = Camera.main.ScreenToWorldPoint
                            (new Vector2(0, 0));

        float xPos = Random.Range(min.x, max.x);
        float yPos = Random.Range(min.y, max.y);
        transform.position = new Vector2(xPos, yPos);
    }
}
