using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script is the base rat script and all the
/// other rats would inherit from this script
/// </summary>
public class bRat : MonoBehaviour
{
    
    [SerializeField] protected float moveSpeed = 0.5f;
    [SerializeField] protected float distance = 20;

    public Transform target;

    // At the start, find the player


   protected virtual void FindPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Transform>();
        if (target == null)
        {
            Debug.Log("Player not found! Make sure the player has the 'Player' tag.");// just to check if I have applied the tag to the right game object
        }
    }

    private void Update()
    {
        Move();//call the move function
    }

    //This function is responsible for the tracking system of the rats, other rats would also inherit this function but I will override them so they have different speeds.
    protected virtual void Move()
    {
        if (target != null && Vector2.Distance(transform.position, target.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else if (target == null)// just to check if I have applied the tag to the right game object
        {
            Debug.Log("Target is null. Ensure the player is tagged correctly.");
        }
    }
}
