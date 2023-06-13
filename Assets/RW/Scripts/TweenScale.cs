// The TweenScale script is responsible for scaling an object over time.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    // variables needed for the script
    public float targetScale; 
    public float timeToReachTarget; 
    private float startScale;  
    private float percentScaled; 
    // Start is called before the first frame update
    void Start()
    {
       startScale = transform.localScale.x; 
    }

    // Update is called once per frame
    void Update()
    {
         // If the scaling progress is less than 100%
        if (percentScaled < 1f) 
        {
            percentScaled += Time.deltaTime / timeToReachTarget; 
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); 
            transform.localScale = new Vector3(scale, scale, scale); 
        }
    }
}
