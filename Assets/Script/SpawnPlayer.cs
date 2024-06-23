using Script;
using UnityEngine;

public class SpawnPlayer : BaseSpawner
{
    [SerializeField] private GameObject playerPrefab;
    protected override void Start()
    {
        base.Start();
        Spawn();
    }

    public override void Spawn()
    {
        Instantiate(playerPrefab, GetRandomPosition(), Quaternion.identity);
    }
}