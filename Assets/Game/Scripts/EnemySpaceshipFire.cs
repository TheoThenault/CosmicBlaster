using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpaceshipFire : MonoBehaviour
{
    public GameObject Bullet;

    public float FiringDelay = 0.5f;

    private float lastFire = 0f;

    private GameObject AsteroidsManager = null;

    public AudioSource FireSound = null;

    // Start is called before the first frame update
    void Start()
    {
        AsteroidsManager = GameObject.Find("AsteroidsManager");
    }

    // Update is called once per frame
    void Update()
    {
        // L'enemi attaque toujours 
        bool fire = true;

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
                        EnemyBulletBehavior behavior = newBullet.GetComponent<EnemyBulletBehavior>();
                        behavior.Init(this.AsteroidsManager);
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
