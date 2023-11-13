using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem.Controls;

public class EnemyBulletBehavior : MonoBehaviour
{
    public float BulletVelocity = 10f;

    public float MaxDistance = 1000f;


    public GameObject Spaceship = null;

    public GameObject EnemySpaceship = null;


    private Transform m_transform = null;

    private Vector3 movementDirection = new Vector3(0f, 1f, 0f);

    private PlayerStatistics PlayerStatistics = null;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
        if(EnemySpaceship != null)
        {
            if (m_transform != null)
            {
                Vector3 SpaceshipPosition = EnemySpaceship.transform.position;
                m_transform.position = SpaceshipPosition;
            }
        }
        if(Spaceship != null)
        {
            PlayerStatistics = Spaceship.GetComponent<PlayerStatistics>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(m_transform != null) 
        { 
            m_transform.Translate(new Vector3(0f, 1f, 0f) * 0.1f);

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
        if(collision != null && collision.gameObject != null && collision.gameObject.tag == "Spaceship")
        {
            Destroy(this.gameObject);
            Debug.Log("HIT");
        }
    }

}
