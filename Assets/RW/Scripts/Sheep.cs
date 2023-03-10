using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{

    public float runSpeed; 
    public float gotHayDestroyDelay; 
    private bool hitByHay; 
    private bool dropped;
    public float inc = 0.1f;

    public float dropDestroyDelay; 
    private Collider myCollider; 
    private Rigidbody myRigidbody; 

    private SheepSpawner sheepSpawner;

    public float heartOffset; 
    public GameObject heartPrefab; 

    public void SetSpawner(SheepSpawner spawner)
    {
        // int numSheepSpawned = sheepSpawner.sheepList.Count;
        runSpeed += inc;
        sheepSpawner = spawner;
    
    }

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true; 
        runSpeed = 0;
        SoundManager.Instance.PlaySheepHitClip();
        Destroy(gameObject, gotHayDestroyDelay);
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0; 
        tweenScale.timeToReachTarget = gotHayDestroyDelay;
        GameStateManager.Instance.SavedSheep();
    }


    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Hay") && !hitByHay) 
        {
            Destroy(other.gameObject);  // hay bale
            HitByHay(); 
        }
        else if (other.CompareTag("DropSheep") && !dropped)
        {
            Drop();
        }
    }

    private void Drop()
    {
        dropped = true;
        myRigidbody.isKinematic = false; 
        myCollider.isTrigger = false;
        SoundManager.Instance.PlaySheepDroppedClip(); 
        Destroy(gameObject, dropDestroyDelay); 
        GameStateManager.Instance.DroppedSheep();
        sheepSpawner.RemoveSheepFromList(gameObject);
    }
}
