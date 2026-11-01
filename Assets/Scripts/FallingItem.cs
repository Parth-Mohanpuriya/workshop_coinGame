using UnityEngine;
 
public class FallingItem : MonoBehaviour
{
    public bool isBomb = false;      // tick this on the Bomb prefab only
    public bool isGrow = false;      // tick this on the Grow prefab only
    public bool isShrink = false;    // tick this on the Shrink prefab only
    // if none of the three boxes is ticked, the item is a coin
 
    public float minSpeed = 2.5f;    // slowest possible fall speed
    public float maxSpeed = 5f;      // fastest possible fall speed
 
    float fallSpeed;                 // the speed this item picked for itself
 
    void Start()
    {
        // pick a random speed between minSpeed and maxSpeed
        fallSpeed = Random.Range(minSpeed, maxSpeed);
    }
 
    void Update()
    {
        // distance to fall in this frame
        float distance = fallSpeed * Time.deltaTime;
 
        // move down (negative y)
        transform.Translate(0f, -distance, 0f);
 
        // if the item fell below the screen, delete it
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}