using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2.0f;
    private Transform target;
    public PlayerData playerData;

    void Start()
    {
        target = pointB;
    }

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (target == pointA && Vector3.Distance(transform.position, pointA.position) < 0.1f)
        {
            target = pointB;
        }
        else if (target == pointB && Vector3.Distance(transform.position, pointB.position) < 0.1f)
        {
            target = pointA;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public MainPlayerScript playerScript;
    // This method will be called when the player collides with a hazard
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Respawn();
        }
    }

    // This method will reset the level when called 
    private void Respawn()
    {
        playerData.playerHealth -= 1; // Use playerHealth from PlayerData
        playerScript.UpdateHealthText();
        playerScript.transform.position = playerData.playerPosition;  // Reset the player's position to the last checkpoint

        // Reload the scene only if health is 0
        if (playerData.playerHealth <= 0) // Use playerHealth from PlayerData
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
