using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpaceshipMovement : MonoBehaviour
{
    private Vector3 m_movement;

    private Vector3 m_rotation;

    public float EnemyLateralSpeed = 0.05f;

    public float EnemyLongitudinalSpeed = 1f;

    public float targetRotationAngleWhenTurning = 45f;
    public float rotationTime = 0.3f;

    public float StartPosition = 36f;

    public float MinimalPositionOnX = -12f;
    public float MaximalPositionOnX = 12f;

    public float direction = 0f;
    private float directionDuration = 0f;
    private float lastDirectionChange = 0f;

    private EnemyManager enemyManager = null;

    // Start is called before the first frame update
    void Start()
    {
        float positionOnX = Random.Range(MinimalPositionOnX, MaximalPositionOnX);

        Vector3 pos = transform.position;
        pos.Set(positionOnX, 0f, StartPosition);
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        var targetRotation = 45 * -direction;
        Quaternion qtargetRotation = Quaternion.Euler(transform.rotation.x, 180, targetRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, qtargetRotation, Time.deltaTime / rotationTime);

        m_movement.Set(direction, 0f, 0f);
        m_movement.Normalize();

        chooseDirection();

        Vector3 pos = new Vector3(0, 0, EnemyLongitudinalSpeed);
        pos +=  m_movement * EnemyLateralSpeed;

        pos.y = 0;
        transform.Translate(pos);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        if (transform.position.x > MaximalPositionOnX)
            transform.position = new Vector3(MaximalPositionOnX, 0, transform.position.z);
        if (transform.position.x < MinimalPositionOnX)
            transform.position = new Vector3(MinimalPositionOnX, 0, transform.position.z);

        if (transform.position.z < -20)
        {
            enemyManager.DestroyEnemy(this.gameObject);
        }
    }

    public void Init (EnemyManager em)
    {
        enemyManager = em;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void chooseDirection()
    {
        float delta = Time.time - lastDirectionChange;
        if (delta > directionDuration)
        {
            direction = Random.Range(-1f, 1f);
            directionDuration = Random.Range(0.1f, 0.8f);

            lastDirectionChange = Time.time;
        }
    }
}
