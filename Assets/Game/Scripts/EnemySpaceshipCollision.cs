using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceshipCollision : MonoBehaviour
{
    public GameObject Explosion = null;

    public AudioSource ExplosionSound = null;

    private bool m_spaceshipDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void HandleCollisions(Collision collision)
    {
        // TODO Mettre à jour pour l'enemi
        /*
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
                        {
                            Instantiate(Explosion, transform.position, transform.rotation);

                            if(ExplosionSound != null)
                                Instantiate(ExplosionSound, transform.position, transform.rotation).PlayDelayed(0.1f);
                        }

                        Destroy(this.gameObject);
                    }
                }
            }
        }
        */
    }
}
