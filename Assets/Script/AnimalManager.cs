using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance { get; private set; }

    private List<GameObject> followingAnimals = new();

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

    public void AddFollowingAnimal(GameObject animal)
    {
        followingAnimals.Add(animal);
    }

    public void RemoveFollowingAnimal(GameObject animal)
    {
        followingAnimals.Remove(animal);
    }

    public int GetFollowingAnimalsCount()
    {
        return followingAnimals.Count;
    }
}