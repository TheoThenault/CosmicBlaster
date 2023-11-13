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
        if (!m_spaceshipDestroyed && collision != null && collision.gameObject != null && collision.gameObject.tag != "EnemyBullet" && collision.gameObject.tag != "Asteroid")
        {
            if(collision.gameObject.tag == "Bullet")
            {
                // 3 balles pour tuer ? 
            }

            Destroy(this.gameObject);
        }
    }
}
