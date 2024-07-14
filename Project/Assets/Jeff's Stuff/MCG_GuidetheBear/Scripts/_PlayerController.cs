using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _PlayerController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private int currentPointIndex = 0;
    private bool isMoving = false;
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        lineRenderer = GameObject.FindObjectOfType<LineDrawing>().GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartMoving();
        }

        if (isMoving)
        {
            MoveAlongLine();
        }
    }

    private void StartMoving()
    {
        if (lineRenderer.positionCount > 0)
        {
            transform.position = lineRenderer.GetPosition(0);
            currentPointIndex = 1;
            isMoving = true;
        }
    }

    private void MoveAlongLine()
    {
        if (currentPointIndex < lineRenderer.positionCount)
        {
            Vector3 targetPosition = lineRenderer.GetPosition(currentPointIndex);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                currentPointIndex++;
            }
        }
        else
        {
            isMoving = false;
        }
    }
}
