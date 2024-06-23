using UnityEngine;

public class CheckAnimalTag : MonoBehaviour
{
    private ScoreCounter scoreCounter;

    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        scoreCounter.SetTag(other.tag);
    }
}