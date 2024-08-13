using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardController : MonoBehaviour
{
    public MainPlayerScript playerScript;
    public PlayerData playerData; // Reference to PlayerData ScriptableObject

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
        playerScript._health -= 1;
        playerScript.UpdateHealthText();


        // Reset the player's position
        playerScript.transform.position = playerData.playerPosition;

        // Reload the scene only if health is 0
        if (playerScript._health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
