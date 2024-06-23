using Script;
using UnityEngine;

public class SpawnYard : BaseSpawner
{
    public static SpawnYard Instance { get; private set; }

    public delegate void YardSpawned(GameObject yard);
    public event YardSpawned OnYardSpawned;

    [SerializeField] private GameObject yardPrefab;
    private GameObject spawnedYard;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
        Spawn();
    }

    public override void Spawn()
    {
        spawnedYard = Instantiate(yardPrefab, GetYardRandomPosition(), Quaternion.identity);
        OnYardSpawned?.Invoke(spawnedYard);
    }

    public GameObject SpawnYardObject => spawnedYard;
    private Vector3 GetYardRandomPosition()
    {
        Renderer renderer = yardPrefab.GetComponent<Renderer>();
        float halfWidth = renderer.bounds.size.x / 2;
        float halfHeight = renderer.bounds.size.y / 2;
    
        float x = Random.Range(minPosition.x + halfWidth, maxPosition.x - halfWidth);
        float y = Random.Range(minPosition.y + halfHeight, maxPosition.y - halfHeight);
    
        return new Vector3(x, y, 0);
    }
}