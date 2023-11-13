using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float SpawnRate = 2f;

    private int EnemyCount = 0;

    public int MaxEnemyCount = 10;

    public EnemySpaceshipFire EnemySpaceshipPrefab = null;

    public GameObject Spaceship = null;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        if (EnemyCount < MaxEnemyCount)
        {
            if (EnemySpaceshipPrefab != null)
            {
                var newEnemy = Instantiate(EnemySpaceshipPrefab);
                newEnemy.Init(Spaceship);
                var newEnemyCollisionHandler = newEnemy.GetComponent<EnemySpaceshipCollision>();
                if (newEnemyCollisionHandler != null)
                    newEnemyCollisionHandler.Init(this);

                var newEnemyMovement = newEnemy.GetComponent<EnemySpaceshipMovement>();
                if (newEnemyMovement != null)
                    newEnemyMovement.Init(this);
                EnemyCount++;
            }
        }
    }

    public void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
        EnemyCount--;
    }
}
