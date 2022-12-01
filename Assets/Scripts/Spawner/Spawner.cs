using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform _spawnContainer;
    [SerializeField] private int _reapeatCount;
    [SerializeField] private int _distanceBetweenFullLine;
    [SerializeField] private int _distanceBetweenRandomLine;

    [Header("Block")]
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private int _blockSpawnChance;

    [Header("Wall")]
    [SerializeField] private Wall _wallTemplate;
    [SerializeField] private int _wallSpawnChance;

    private BlockSpawnPoint[] _blockSpawnPoints;
    private WallSpawnPoint[] _wallSpawnPoints;

    private void Start()
    {
        _blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        _wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();

        for (int i = 0; i < _reapeatCount; i++)
        {
            MoveSpawner(_distanceBetweenFullLine);
            GenerateRandomLine(_wallSpawnPoints, _wallTemplate.gameObject, _wallSpawnChance);
            GenerateFullLine(_blockSpawnPoints, _blockTemplate.gameObject);

            MoveSpawner(_distanceBetweenRandomLine);
            GenerateRandomLine(_wallSpawnPoints, _wallTemplate.gameObject, _wallSpawnChance);
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
