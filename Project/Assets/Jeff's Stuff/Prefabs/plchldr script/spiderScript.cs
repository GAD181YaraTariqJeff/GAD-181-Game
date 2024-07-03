using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is dedicated for the spider
/// </summary>
public class spiderScript : MonoBehaviour
{
    Transform tr;
    GameController gameController;

    void Start()
    {
        tr = GetComponent<Transform>();
        gameController = FindObjectOfType<GameController>();
    }

    void FixedUpdate()
    {
        tr.position -= new Vector3(0f, 0.12f, 0f);
        if (tr.position.y < -7f) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Basket")
        {
            Debug.Log("YOU GOT A SPIDER!");
            gameController.DeductScore(1); // Deducts 1 point from the score
            Destroy(this.gameObject);
        }
    }
}
