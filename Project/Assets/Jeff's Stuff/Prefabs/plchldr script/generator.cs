using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// This script is directly responsible for the generation of
/// spiders and fruits so I made it in a way that its like 80/20
/// 80% for a fruit to spawn and 20 for a spider to spawn.
/// </summary>

public class generator : MonoBehaviour
{
    float timer = 1;
  public  GameObject[] gObj;

    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        else 
        {
            int chance = Random.Range(1, 101);
            float pos_x = Random.Range(-4.0f, 4.0f);

            if (chance <= 20) 
            {
                Instantiate(gObj[1], new Vector3(pos_x, 6.0f,0.1f), new Quaternion(0,0, 0, 0)); 
            }
            else 
            {
                Instantiate(gObj[0], new Vector3(pos_x, 6.0f, 0.1f), new Quaternion(0, 0, 0, 0));
            }

            timer = 0.5f;
        }
    }
}
