using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipFire : MonoBehaviour
{
    public GameObject Bullet;

    public float FiringDelay = 0.5f;

    private float lastFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float fire = Input.GetAxis("Fire1");

        if( fire > 0.9 ) 
        {
            float delta = Time.time - lastFire;
            if(delta > FiringDelay )
            {
                if (Bullet != null)
                {
                    GameObject newBullet = Instantiate(Bullet);
                    if (newBullet != null)
                    {
                        newBullet.SetActive(true);
                        Transform transform = newBullet.GetComponent<Transform>();
                    }
                }
                lastFire = Time.time;
            }
        }
    }
}
