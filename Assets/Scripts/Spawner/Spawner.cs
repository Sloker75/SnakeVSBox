using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnContainer;
    [SerializeField] private int _reapeatCount;
    [SerializeField] private int _distanceBetweenFullLine;
    [SerializeField] private int _distanceBetweenRandomLine;

    [SerializeField] private Block _blockTemplate;
    [SerializeField] private int _blockSpawnChance;

    private SpawnerPoint[] _blockSpawnPoints;

    private void Start()
    {
        _blockSpawnPoints = GetComponentsInChildren<SpawnerPoint>();

        for (int i = 0; i < _reapeatCount; i++)
        {
            MoveSpawner(_distanceBetweenFullLine);
            GenerateFullLine(_blockSpawnPoints, _blockTemplate.gameObject);
            MoveSpawner(_distanceBetweenRandomLine);
            GenerateRandomLine(_blockSpawnPoints, _blockTemplate.gameObject, _blockSpawnChance);
        }
    }

    private void GenerateRandomLine(SpawnerPoint[] spawnPoints, GameObject spawnObject, int spawnChance)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
            if (Random.Range(0, 100) < spawnChance)
                GenerateElement(spawnPoints[i].transform.position, spawnObject);
    }

    private void GenerateFullLine(SpawnerPoint[] spawnerPoints, GameObject spawnObject)
    {
        for(int i = 0; i < spawnerPoints.Length; i++)
            GenerateElement(spawnerPoints[i].transform.position, spawnObject);
    }

    private GameObject GenerateElement(Vector3 spawnPoint, GameObject spawnObject)
    {
        return Instantiate(spawnObject, spawnPoint, Quaternion.identity,_spawnContainer);
    }

    private void MoveSpawner(int distanceY)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceY, transform.position.z);
    }

}
