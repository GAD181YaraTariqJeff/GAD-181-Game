using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private GameMngr gameMngr;

    void Start()
    {
        // Find the GameMngr in the scene
        gameMngr = FindObjectOfType<GameMngr>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a projectile or player (or however your game determines a hit)
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Inform the GameMngr that a target has been shot
            gameMngr.TargetShot();
            // Destroy the target
            Destroy(gameObject);
        }
    }
}
