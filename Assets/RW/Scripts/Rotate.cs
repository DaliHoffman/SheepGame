// This script controls the rotation of the hay bale

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Rotate the hay bale in the specified direction and speed
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
