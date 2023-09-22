using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPosition : MonoBehaviour
{
    public GameObject Camera;

    public GameObject Star;

    Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Camera.transform.position;
        Vector3 starPos = Star.transform.position;

        Vector3 line = cameraPos - starPos;
        line.Normalize();
        line *= 3;

        Debug.Log(line);

        m_transform.position = starPos + line;
    }
}
