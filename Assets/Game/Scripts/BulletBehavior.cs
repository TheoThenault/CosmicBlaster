using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float BulletVelocity = 10f;

    public float MaxDistance = 1000f;

    private Transform m_transform = null;

    public GameObject Spaceship = null;

    private Vector3 movementDirection = new Vector3(0f, -1f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>(); 
        if(Spaceship != null && m_transform != null)
        {
            Vector3 SpaceshipPosition = Spaceship.transform.position;
            m_transform.position = SpaceshipPosition;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
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
}
