using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        var t = Mathf.PingPong(time, 1);
        transform.position = Vector3.Lerp(Vector3.zero, Vector3.one, t);
    }
}
