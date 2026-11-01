
using UnityEngine;
using UnityEngine.InputSystem;
 
public class Catcher : MonoBehaviour
{
    public float speed = 8f;
    public float leftEdge = -8.8f;
    public float rightEdge = 8.8f;
    public float minWidth = 1f;
    public float maxWidth = 4f;
    public float widthChange = 0.5f;
    public GameManager gameManager;
 
    void Update()
    {
        if (gameManager.isGameOver == false)
        {
            float move = 0f;
 
            if (Keyboard.current.leftArrowKey.isPressed)
            {
                move = -1f;
            }
 
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                move = 1f;
            }
 
            float distance = move * speed * Time.deltaTime;
 
            transform.Translate(distance, 0f, 0f);
 
            float halfWidth = transform.localScale.x / 2f;
 
            float leftLimit = leftEdge + halfWidth;
            float rightLimit = rightEdge - halfWidth;
 
            if (transform.position.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, transform.position.y, 0f);
            }
 
            if (transform.position.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, transform.position.y, 0f);
            }
        }
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
        FallingItem item = other.GetComponent<FallingItem>();
 
        if (item != null && gameManager.isGameOver == false)
        {
            if (item.isBomb == true)
            {
                gameManager.LoseLife();
            }
            else if (item.isGrow == true)
            {
                MakePaddleBigger();
            }
            else if (item.isShrink == true)
            {
                MakePaddleSmaller();
            }
            else
            {
                gameManager.AddScore();
            }
 
            Destroy(other.gameObject);
        }
    }
 
    void MakePaddleBigger()
    {
        float newWidth = transform.localScale.x + widthChange;
 
        if (newWidth > maxWidth)
        {
            newWidth = maxWidth;
        }
 
        transform.localScale = new Vector3(newWidth, transform.localScale.y, 1f);
    }
 
    void MakePaddleSmaller()
    {
        float newWidth = transform.localScale.x - widthChange;
 
        if (newWidth < minWidth)
        {
            newWidth = minWidth;
        }
 
        transform.localScale = new Vector3(newWidth, transform.localScale.y, 1f);
    }
}
 

