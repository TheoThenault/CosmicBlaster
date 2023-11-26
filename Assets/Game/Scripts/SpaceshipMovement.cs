using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    Transform SpaceshipTransform;

    private Vector3 m_movement;

    private Vector3 m_rotation;

    public float SpaceshipSpeedModifier = 0.05f;

    public float MinimalPositionOnX = -12f;
    public float MaximalPositionOnX =  12f;

    public float targetRotationAngleWhenTurning = 45f;
    public float rotationTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        SpaceshipTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        var targetRotation = 45 * -horizontal;
        Quaternion qtargetRotation = Quaternion.Euler(SpaceshipTransform.rotation.x, SpaceshipTransform.rotation.y, targetRotation);
        SpaceshipTransform.rotation = Quaternion.Lerp(SpaceshipTransform.rotation, qtargetRotation, Time.deltaTime / rotationTime);

        m_movement.Set(horizontal, 0f, 0f);
        m_movement.Normalize();
    }

    void Update()
    {
        Vector3 pos = m_movement * SpaceshipSpeedModifier;

        pos.y = 0;
        SpaceshipTransform.Translate(pos);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        if (transform.position.x > MaximalPositionOnX)
            transform.position = new Vector3(MaximalPositionOnX, 0, transform.position.z);
        if (transform.position.x < MinimalPositionOnX)
            transform.position = new Vector3(MinimalPositionOnX, 0, transform.position.z);

    }

}
