using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRelay : MonoBehaviour
{
    public SpaceshipCollision Spaceship = null;

    private void OnCollisionEnter(Collision collision)
    {
        if(Spaceship != null)
            Spaceship.HandleCollisions(collision);
    }
}
