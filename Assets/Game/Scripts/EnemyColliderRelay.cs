using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderRelay : MonoBehaviour
{
    public EnemySpaceshipCollision Spaceship = null;

    private void OnCollisionEnter(Collision collision)
    {
        if(Spaceship != null)
            Spaceship.HandleCollisions(collision);
    }
}
