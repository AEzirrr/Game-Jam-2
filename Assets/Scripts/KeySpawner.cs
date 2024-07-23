using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject keyPrefab; 

    [SerializeField]
    private List<Transform> spawnPoints;

    private void Start()
    {
        if (spawnPoints.Count == 0)
        {
            return;
        }

        SpawnKey();
    }

    private void SpawnKey()
    {
        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[randomIndex];
        Debug.Log("Spawned at:" + spawnPoint);

        GameObject spawnedKey = Instantiate(keyPrefab, spawnPoint.position, Quaternion.Euler(0, 45, 0));

    }
}
