using UnityEngine;

namespace Script
{
    public abstract class BaseSpawner: MonoBehaviour, ISpawnable
    {
        protected Vector3 minPosition;
        protected Vector3 maxPosition;

        protected virtual void Start()
        {
            GetScreenBorder();
        }

        private void GetScreenBorder()
        {
            minPosition = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
            maxPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.nearClipPlane));
        }

        public Vector3 GetRandomPosition()
        {
            float x = Random.Range(minPosition.x, maxPosition.x);
            float y = Random.Range(minPosition.y, maxPosition.y);
            return new Vector3(x, y, 0);
        }

        public abstract void Spawn();
    }
}