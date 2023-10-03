using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCollision : MonoBehaviour
{
    public SpawnAsteroids AsteroidsManager;

    private PlayerStatistics playerStatistics = null;

    public GameObject Explosion = null;

    private bool m_spaceshipDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerStatistics = GetComponent<PlayerStatistics>();
    }


    public void HandleCollisions(Collision collision)
    {
        if (!m_spaceshipDestroyed && collision != null && collision.gameObject != null && collision.gameObject.tag == "Asteroid")
        {

            if (AsteroidsManager != null)
            {
                AsteroidsManager.DestroyAsteroid(collision.gameObject);

                if (playerStatistics != null)
                {
                    playerStatistics.removeHealth();

                    if (playerStatistics.IsDead())
                    {
                        m_spaceshipDestroyed = true;

                        if(Explosion != null)
                            Instantiate(Explosion, transform.position, transform.rotation);

                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}