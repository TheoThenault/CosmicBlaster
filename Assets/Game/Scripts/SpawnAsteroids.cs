using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public float SpawnRate = 2f;

    public int AsteroidCount = 0;

    public int MaxAsteroidCount = 10;

    public GameObject AsteroidPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 0f, SpawnRate);
    }

    void SpawnAsteroid()
    {
        if(AsteroidCount < MaxAsteroidCount)
        {
            if(AsteroidPrefab != null)
            {
                GameObject newAsteroid = Instantiate(AsteroidPrefab);
                newAsteroid.SetActive(true);
                AsteroidCount++;
            }
        }
    }

    public void DestroyAsteroid(GameObject Asteroid)
    {
        Destroy(Asteroid);
        AsteroidCount--;
    }
}
