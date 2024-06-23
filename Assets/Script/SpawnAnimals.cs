using System;
using System.Collections;
using Script;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnAnimals : BaseSpawner
{
    [SerializeField] private GameObject animalsPrefab;
    [SerializeField] private int animalsCount;
    [SerializeField] private int animalsCountOnStart;
    [SerializeField] private float minSpawnDelay;
    [SerializeField] private float maxSpawnDelay;
    [SerializeField] private float distanceFromYard;

    private SpawnYard yardSpawner;
    
    protected override void Start()
    {
        base.Start();
        yardSpawner = SpawnYard.Instance;
        if (yardSpawner != null)
        {
            SpawnInitialAnimals();
            StartCoroutine(SpawnAnimalsOverTime());
        }
    }

    private void SpawnInitialAnimals()
    {
        for (int i = 0; i < animalsCountOnStart; i++)
        {
            Spawn();
        }
    }

    private IEnumerator SpawnAnimalsOverTime()
    {
        for (int i = 0; i < animalsCount - animalsCountOnStart; i++)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Spawn();
        }
    }

    public override void Spawn()
    {
        Vector3 spawnPosition;
        do
        {
            spawnPosition = GetRandomPosition();
        } while (IsInsideYard(spawnPosition));

        Instantiate(animalsPrefab, spawnPosition, Quaternion.identity);
    }

    private bool IsInsideYard(Vector3 spawnPosition)
    {
        if (yardSpawner.SpawnYardObject == null) return false;

        Collider2D yardCollider = yardSpawner.SpawnYardObject.GetComponent<Collider2D>();
        Vector2 closestPointOnYard = yardCollider.bounds.ClosestPoint(spawnPosition);

        float distanceToYard = Vector2.Distance(spawnPosition, closestPointOnYard);
        return distanceToYard <= distanceFromYard;
    }
}