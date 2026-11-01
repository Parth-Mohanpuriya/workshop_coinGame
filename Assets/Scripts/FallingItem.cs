using UnityEngine;
 
public class FallingItem : MonoBehaviour
{
    public bool isBomb = false;
    public bool isGrow = false;
    public bool isShrink = false;
 
    public float minSpeed = 2.5f;
    public float maxSpeed = 5f;
 
    float fallSpeed;
 
    void Start()
    {
        fallSpeed = Random.Range(minSpeed, maxSpeed);
    }
 
    void Update()
    {
        float distance = fallSpeed * Time.deltaTime;
 
        transform.Translate(0f, -distance, 0f);
 
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}