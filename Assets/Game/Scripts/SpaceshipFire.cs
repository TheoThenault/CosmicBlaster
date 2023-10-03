using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceshipFire : MonoBehaviour
{
    public GameObject Bullet;

    public float FiringDelay = 0.5f;

    private float lastFire = 0f;

    public GameObject AsteroidsManager = null;

    public AudioSource FireSound = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool fire = Input.GetButton("Fire1");

        if(fire) 
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
                        BulletBehavior behavior = newBullet.GetComponent<BulletBehavior>();
                        behavior.AsteroidsManager = this.AsteroidsManager;
                        PlayFireSound();
                    }
                }
                lastFire = Time.time;
            }
        }
    }

    private void PlayFireSound()
    {
        if(FireSound != null )
        {
            Instantiate(FireSound, transform.position, transform.rotation).Play();
        }
    }
}
