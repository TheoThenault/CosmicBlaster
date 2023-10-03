using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;

public class BulletBehavior : MonoBehaviour
{
    public float BulletVelocity = 10f;

    public float MaxDistance = 1000f;


    public GameObject Spaceship = null;

    public GameObject AsteroidsManager = null;


    private Transform m_transform = null;

    private Vector3 movementDirection = new Vector3(0f, -1f, 0f);

    private PlayerStatistics PlayerStatistics = null;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>(); 
        if(Spaceship != null)
        {
            PlayerStatistics = Spaceship.GetComponent<PlayerStatistics>();

            if (m_transform != null)
            {
                Vector3 SpaceshipPosition = Spaceship.transform.position;
                m_transform.position = SpaceshipPosition;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_transform != null) 
        { 
            m_transform.Translate(movementDirection * BulletVelocity);

            if(Spaceship != null)
            {
                Transform spaceshipTransform = Spaceship.transform;
                if (spaceshipTransform != null)
                {
                    float distance = (spaceshipTransform.position - m_transform.position).magnitude;

                    if (distance > MaxDistance)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null && collision.gameObject != null && collision.gameObject.tag == "Asteroid")
        {
            Destroy(this.gameObject);
            if (AsteroidsManager != null)
            {
                SpawnAsteroids script = AsteroidsManager.GetComponent<SpawnAsteroids>();
                if (script != null)
                { 
                    script.DestroyAsteroid(collision.gameObject);

                    if (PlayerStatistics != null)
                        PlayerStatistics.AddScore();
                }
            }
        }
    }

}
