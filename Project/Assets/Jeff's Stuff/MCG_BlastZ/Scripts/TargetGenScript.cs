using UnityEngine;

public class TargetGenScript : MonoBehaviour
{
    public GameObject targetPrefab;
    public Transform[] spawnPoints; // Array of spawn points for targets

    void Start()
    {
        SpawnTargets();
    }

    void SpawnTargets()
    {
        for (int i = 0; i < GameObject.FindObjectOfType<GameMngr>().totalTargets; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(targetPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }
}
