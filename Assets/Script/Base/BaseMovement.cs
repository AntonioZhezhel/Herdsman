using UnityEngine;

namespace Script
{
    public class BaseMovement : MonoBehaviour, IMoveable
    {
        [SerializeField] protected float speed;
        protected Vector3 targetPosition;

        protected virtual void Start()
        {
            targetPosition = transform.position;
        }

        public virtual void Move(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }

        protected virtual void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        
    }
}