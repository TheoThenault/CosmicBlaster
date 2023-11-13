using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceshipCollision : MonoBehaviour
{
    public GameObject Explosion = null;

    public AudioSource ExplosionSound = null;

    private bool m_spaceshipDestroyed = false;

    public int health = 3;

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
                health--;

                if (health > 0)
                    return;
            }

            Destroy(this.gameObject);
        }
    }
}
