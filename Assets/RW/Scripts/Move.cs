// This script controls the movement of the hay bale
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Vector3 movementSpeed;
    public Space space;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         // Move the hay bale in the specified direction and coordinate space
        transform.Translate(movementSpeed * Time.deltaTime, space);
    }
}
