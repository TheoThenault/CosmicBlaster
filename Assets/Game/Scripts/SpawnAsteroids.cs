using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    public float SpawnRate = 2f;

    private int AsteroidCount = 0;

    public int MaxAsteroidCount = 10;

    public GameObject AsteroidPrefab = null;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawnRate);
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        if(AsteroidCount < MaxAsteroidCount)
        {
            if(AsteroidPrefab != null)
            {
                GameObject newAsteroid = Instantiate(AsteroidPrefab);
                newAsteroid.SetActive(true);
                newAsteroid.AsteroidsManager = this.gameObject;
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
