using UnityEngine;

namespace Script
{
    public class AnimalBehavior: MonoBehaviour
    {
        [SerializeField] private int maxFollowingAnimals;
        [SerializeField] private Collider2D colliderAnimal;

        private AnimalMovement movement;
        private MovementAI movementAI;

        private void Start()
        {
            movement = GetComponent<AnimalMovement>();
            movementAI = GetComponent<MovementAI>();
            
            movement.enabled = false;
            movementAI.enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                StartFollowing();
            }
            else if (other.CompareTag("Yard"))
            {
                EnterYard();
            }
        }

        private void StartFollowing()
        {
            if (AnimalManager.Instance != null &&
                AnimalManager.Instance.GetFollowingAnimalsCount() < maxFollowingAnimals)
            {
                movement.enabled = true;
                movement.StartFollowing();
                movementAI.enabled = false;
                AnimalManager.Instance.AddFollowingAnimal(gameObject);
            }
        }

        private void EnterYard()
        {
            movement.enabled = false;
            movement.StopFollowing();
            colliderAnimal.enabled = false;
            movementAI.SetInsideYard(true);
            movementAI.enabled = true;
            AnimalManager.Instance.RemoveFollowingAnimal(gameObject);
        }
    }
}