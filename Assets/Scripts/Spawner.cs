using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public static Spawner Instace { get; private set; }

    public GameObject enemyPrefab;
    public GameObject owlPrefab;
    private Transform[] spawners;
    private int lastSpawner, currentSpawner;

    void Start () {
        Instace = this;
        spawners = GetComponentsInChildren<Transform>();
	}
	
	public void Spawn()
    {
        currentSpawner = Random.Range(1, 5);
        if(currentSpawner == lastSpawner)
        {
            currentSpawner = differentSpawn();
        }
        Transform spawnPosition = spawners[currentSpawner];
        Instantiate(enemyPrefab, spawnPosition.position, Quaternion.Euler(Vector3.zero));
        lastSpawner = currentSpawner;
    }

    public void SpawnOwl()
    {
        Transform spawnPosition = spawners[Random.Range(1, 5)];
        Instantiate(owlPrefab, spawnPosition.position, Quaternion.Euler(Vector3.zero));
    }

    int differentSpawn()
    {
        while(currentSpawner == lastSpawner)
        {
            currentSpawner = Random.Range(1, 5);
        }
        return currentSpawner;
    }
}
