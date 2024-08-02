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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
