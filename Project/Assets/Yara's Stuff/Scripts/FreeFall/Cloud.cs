using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
     
     Player player;
    public float speed;
    SpriteRenderer SRederer;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    } 
    // Start is called before the first frame update
    void Start()
    {
        SRederer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 pos = transform.position;

        pos.y -= speed * Time.fixedDeltaTime;

        ; 
        float leftLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0f, Camera.main.nearClipPlane)).x;
        float rightLimit = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane)).x;
        float width = SRederer.bounds.extents.x;
        // if(transform.position.x - width< leftLimit)
        // {
        //     transform.position = new Vector2(leftLimit + width, transform.position.y);
        // }
        // if(transform.position.x + width > rightLimit)
        // {
        //     transform.position = new Vector2(rightLimit - width, transform.position.y);
        // }
        if(pos.y <= -25)
        {
            pos.y = 25 ;
            pos.x = Random.Range(leftLimit + width, rightLimit - width);
        }
        transform.position = pos;
    }
    private void OnTriggerEnter2D() {
        FreeFall.hitACloud = true;
        Debug.Log("the could is hit");
    }
}
