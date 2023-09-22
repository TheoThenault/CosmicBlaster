using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    Transform SpaceshipTransform;

    private Vector3 m_movement;

    public float SpaceshipSpeedModifier = 0.05f;
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
        Vector3 pos = SpaceshipTransform.position;

        pos += m_movement * SpaceshipSpeedModifier;

        if (pos.x > 12)
            pos.Set(12, 0f, 0f);
        if (pos.x < -12)
            pos.Set(-12, 0f, 0f);

        SpaceshipTransform.position = pos;
    }

}
