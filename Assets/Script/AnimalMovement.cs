using UnityEngine;

namespace Script
{
    public class AnimalMovement : BaseMovement
    {
        private Transform player;
        private bool isFollowing = false;

        protected override void Start()
        {
            base.Start();
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void StartFollowing()
        {
            isFollowing = true;
        }

        public void StopFollowing()
        {
            isFollowing = false;
        }

        protected override void Update()
        {
            if (isFollowing && player != null)
            {
                targetPosition = player.position;
            }
            base.Update();
        }
    }
}