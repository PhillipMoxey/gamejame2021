using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private bool isGameActive = true;

    [SerializeField] private GameObject enemyPrefab;

    private float xSpawnRange = 9.2f;
    private float ySpawn = 8f;
    public float spawnRate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (isGameActive)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawn, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
