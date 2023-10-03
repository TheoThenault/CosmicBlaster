using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceKill : MonoBehaviour
{
    public AudioSource audioSource = null;

    private bool wasPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource != null)
        {
            if (wasPlaying && !audioSource.isPlaying)
            {
                Destroy(this.gameObject);
            }

            if(!wasPlaying && audioSource.isPlaying)
            {
                wasPlaying = true;
            }
        }
        
    }
}
