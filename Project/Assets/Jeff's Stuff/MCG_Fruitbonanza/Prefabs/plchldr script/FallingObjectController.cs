
using UnityEngine;

enum FallingObjectType 
{
    Fruit=0,
    Spider=1
}
/// <summary>
/// This script is dedicated for the fruit
/// </summary>
public class FallingObjectController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]FallingObjectType type;
    GameController gameController;
    [SerializeField] private float speed=-10;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        rb=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, speed);
        if (transform.position.y < -7f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (type == FallingObjectType.Fruit)
            {
                Debug.Log("YOU GOT A FRUIT");
                gameController.AddScore(1);
                Destroy(this.gameObject);
            }
            else if(type == FallingObjectType.Spider)
            {
                Debug.Log("YOU GOT A SPIDER!");
                gameController.DeductScore(1); // Deducts 1 point from the score
                Destroy(this.gameObject);
            }
        }
    }
}


