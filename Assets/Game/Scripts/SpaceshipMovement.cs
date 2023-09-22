using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    Transform SpaceshipTransform;

    private Vector3 m_movement;
    // Start is called before the first frame update
    void Start()
    {
        SpaceshipTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        m_movement.Set(horizontal, 0f, 0f);
        m_movement.Normalize();
    }

    private void Update()
    {
        SpaceshipTransform.position += m_movement;
    }

}
