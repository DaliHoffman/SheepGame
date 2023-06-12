// This script destroys the game object it is attached to after a specified time.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{

    public float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        // Destroy the game object after the specified time has elapsed.
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
