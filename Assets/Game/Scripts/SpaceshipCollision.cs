using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipCollision : MonoBehaviour
{
    public SpawnAsteroids AsteroidsManager;

    private PlayerStatistics playerStatistics = null;

    public GameObject Explosion = null;

    public AudioSource ExplosionSound = null;

    private bool m_spaceshipDestroyed = false;

    private Renderer m_renderer = null;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        playerStatistics = GetComponent<PlayerStatistics>();
        m_renderer.enabled = true;
    }

    private void destroyShip()
    {
        m_renderer.enabled = false;
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
                        {
                            Instantiate(Explosion, transform.position, transform.rotation);

                            if(ExplosionSound != null)
                                Instantiate(ExplosionSound, transform.position, transform.rotation).PlayDelayed(0.1f);
                        }

                        destroyShip();
                    }
                }
            }
        }

        if (!m_spaceshipDestroyed && collision != null && collision.gameObject != null && collision.gameObject.tag == "EnemyBullet")
        {
            if (playerStatistics != null)
            {
                playerStatistics.removeHealth();

                if (playerStatistics.IsDead())
                {
                    m_spaceshipDestroyed = true;

                    if (Explosion != null)
                    {
                        Instantiate(Explosion, transform.position, transform.rotation);

                        if (ExplosionSound != null)
                            Instantiate(ExplosionSound, transform.position, transform.rotation).PlayDelayed(0.1f);
                    }

                    destroyShip();
                }
            }
        }

        if (!m_spaceshipDestroyed && collision != null && collision.gameObject != null && collision.gameObject.tag == "EnemySpaceship")
        {
            if (playerStatistics != null)
            {
                while(!playerStatistics.IsDead())
                    playerStatistics.removeHealth(999);

                m_spaceshipDestroyed = true;

                if (Explosion != null)
                {
                    Instantiate(Explosion, transform.position, transform.rotation);

                    if (ExplosionSound != null)
                        Instantiate(ExplosionSound, transform.position, transform.rotation).PlayDelayed(0.1f);
                }

                destroyShip();
            }
        }
    }
}
