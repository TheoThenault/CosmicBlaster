using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPosition : MonoBehaviour
{
    public GameObject Spaceship = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Spaceship != null)
        {
            transform.position = Spaceship.transform.position;
        }
    }
}
