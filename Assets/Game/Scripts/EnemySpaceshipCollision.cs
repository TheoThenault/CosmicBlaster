using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceshipCollision : MonoBehaviour
{
    public GameObject Explosion = null;

    public AudioSource ExplosionSound = null;

    public int health = 3;

    private EnemyManager m_manager;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init (EnemyManager manager)
    {
        m_manager = manager;   
    }

    public void HandleCollisions(Collision collision)
    {
        if (collision != null && collision.gameObject != null && collision.gameObject.tag != "EnemyBullet" && collision.gameObject.tag != "Asteroid"
            && collision.gameObject.tag != "EnemySpaceship")
        {
            if(collision.gameObject.tag == "Bullet")
            {
                health--;

                //if (health > 0)
                //    return;
            }

            m_manager.DestroyEnemy(this.gameObject);
        }
    }
}
