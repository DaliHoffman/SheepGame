// This script destroys the game object it is attached to when it collides with
// another object that has a specific tag.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;

    private void OnTriggerEnter(Collider other) 
    {
        // Check if the colliding object has a tag that matches the tagFilter.
        if (other.CompareTag(tagFilter)) 
        {
            // Destroy the game object this script is attached to.
            Destroy(gameObject); 
        }
    }

}
