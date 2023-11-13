using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceshipMovement : MonoBehaviour
{
    public float AsteroidSpeed = 0.01f;

    public float StartPosition = 120f;

    public float MinimalPositionOnX = -12f;
    public float MaximalPositionOnX = 12f;

    private GameObject AsteroidsManager = null;

    public void Init(GameObject _AsteroidsManager)
    {
        this.AsteroidsManager = _AsteroidsManager;
    }

    // Start is called before the first frame update
    void Start()
    {
        float positionOnX = Random.Range(MinimalPositionOnX, MaximalPositionOnX);

        float newScale = Random.Range(1f, 3f);

        Vector3 scale = transform.localScale;
        scale *= newScale;
        transform.localScale = scale;

        Vector3 pos = transform.position;
        pos.Set(positionOnX, 0f, StartPosition);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.Set(pos.x, pos.y, pos.z - AsteroidSpeed);
        transform.position = pos;

        if(pos.z < -20)
        {
            if (AsteroidsManager != null)
            {
                SpawnAsteroids script = AsteroidsManager.GetComponent<SpawnAsteroids>();
                if (script != null)
                {
                    script.DestroyAsteroid(this.gameObject);
                }
            }
        }
    }
}