using UnityEngine;

public class MovementAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distanceFromYard;
    [SerializeField] private float distanceFromBorderYard;
    [SerializeField] private float pathfindingStepSize;
    [SerializeField] private int maxPathfindingIterations;

    private SpawnYard yardSpawner;
    private Vector3 targetPosition;
    private bool isInsideYard = false;

    private void Start()
    {
        yardSpawner = SpawnYard.Instance;
        if (yardSpawner != null)
        {
            yardSpawner.OnYardSpawned += OnYardSpawned;
        }
    }

    private void OnEnable()
    {
        SetNewTargetPosition();
    }
    
    public void SetInsideYard(bool insideYard)
    {
        isInsideYard = insideYard;
    }

    private void OnYardSpawned(GameObject yard)
    {
        SetNewTargetPosition();
    }

    private void Update()
    {
        if (yardSpawner == null) return;

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNewTargetPosition();
        }
        else
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

        if (IsPositionValid(newPosition))
        {
            transform.position = newPosition;
        }
        else
        {
            SetNewTargetPosition();
        }
    }

    private void SetNewTargetPosition()
    {
        int attempts = 0;
        do
        {
            targetPosition = SpawnYard.Instance.GetRandomPosition();
            attempts++;
            if (attempts > 100)
            {
                Debug.LogWarning("Could not find a valid target position after 100 attempts.");
                targetPosition = transform.position;
                break;
            }
        } while (!IsPathClear(transform.position, targetPosition));
    }

    private bool IsPathClear(Vector3 start, Vector3 end)
    {
        int iterations = 0;
        Vector3 current = start;

        while (Vector3.Distance(current, end) > pathfindingStepSize)
        {
            Vector3 direction = (end - current).normalized;
            Vector3 nextStep = current + direction * pathfindingStepSize;

            if (!IsPositionValid(nextStep))
            {
                return false;
            }

            current = nextStep;
            iterations++;

            if (iterations > maxPathfindingIterations)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsPositionValid(Vector3 position)
    {
        if (yardSpawner == null || yardSpawner.SpawnYardObject == null)
            return true;

        Collider2D colliderYard = yardSpawner.SpawnYardObject.GetComponent<Collider2D>();
        if (colliderYard == null)
            return true;

        Vector2 closestPointOnYard = colliderYard.bounds.ClosestPoint(position);
        float distanceToYard = Vector2.Distance(position, closestPointOnYard);

        return isInsideYard ? distanceToYard <= distanceFromBorderYard : distanceToYard >= distanceFromYard;
    }
}