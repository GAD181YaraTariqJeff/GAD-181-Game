using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.U2D;

public class PlayerFall : MonoBehaviour
{
    float horizontalMovement;
    public float speed;
    SpriteRenderer SRederer;
    // Start is called before the first frame update
    void Start()
    {
        SRederer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal"); 
        transform.Translate(Vector2.right * horizontalMovement * Time.deltaTime * speed); 
        float leftLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0f, Camera.main.nearClipPlane)).x;
        float rightLimit = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane)).x;
        float width = SRederer.bounds.extents.x;
        if(transform.position.x - width< leftLimit)
        {
            transform.position = new Vector2(leftLimit + width, transform.position.y);
        }
        if(transform.position.x + width > rightLimit)
        {
            transform.position = new Vector2(rightLimit - width, transform.position.y);
        }
    }
    private void OnTriggerEnter2D() {
        FreeFall.hitACloud = true;
        Debug.Log("the could is hit");
    }
}
