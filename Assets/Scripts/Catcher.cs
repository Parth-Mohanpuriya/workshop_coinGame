
using UnityEngine;
using UnityEngine.InputSystem;   // lets me read the keyboard with the new Input System
 
public class Catcher : MonoBehaviour
{
    public float speed = 8f;           // how fast the paddle moves
    public float leftEdge = -8.8f;     // the left edge of the screen
    public float rightEdge = 8.8f;     // the right edge of the screen
    public float minWidth = 1f;        // the paddle can never be shorter than this
    public float maxWidth = 4f;        // the paddle can never be longer than this
    public float widthChange = 0.5f;   // how much the width changes for each item caught
    public GameManager gameManager;    // I drag the GameManager object here in the Inspector
 
    void Update()
    {
        // Only move the paddle if the game is not over
        if (gameManager.isGameOver == false)
        {
            float move = 0f;   // 0 = stand still, -1 = left, 1 = right
 
            if (Keyboard.current.leftArrowKey.isPressed)
            {
                move = -1f;
            }
 
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                move = 1f;
            }
 
            // distance to move in this frame
            float distance = move * speed * Time.deltaTime;
 
            // move the paddle sideways (x), not up/down (y) or forward (z)
            transform.Translate(distance, 0f, 0f);
 
            // half of the paddle's width (the paddle's scale x is its width)
            float halfWidth = transform.localScale.x / 2f;
 
            // the centre of the paddle must stay inside these two limits
            float leftLimit = leftEdge + halfWidth;
            float rightLimit = rightEdge - halfWidth;
 
            // stop the paddle from leaving the screen on the left
            if (transform.position.x < leftLimit)
            {
                transform.position = new Vector3(leftLimit, transform.position.y, 0f);
            }
 
            // stop the paddle from leaving the screen on the right
            if (transform.position.x > rightLimit)
            {
                transform.position = new Vector3(rightLimit, transform.position.y, 0f);
            }
        }
    }
 
    // Unity calls this by itself when a trigger collider touches the paddle
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the thing that touched me has a FallingItem script
        FallingItem item = other.GetComponent<FallingItem>();
 
        if (item != null && gameManager.isGameOver == false)
        {
            if (item.isBomb == true)
            {
                gameManager.LoseLife();    // bomb: lose a life
            }
            else if (item.isGrow == true)
            {
                MakePaddleBigger();        // green item: longer paddle
            }
            else if (item.isShrink == true)
            {
                MakePaddleSmaller();       // purple item: shorter paddle
            }
            else
            {
                gameManager.AddScore();    // coin: score +1
            }
 
            // remove the caught item from the game
            Destroy(other.gameObject);
        }
    }
 
    void MakePaddleBigger()
    {
        float newWidth = transform.localScale.x + widthChange;
 
        // do not go above the biggest allowed width
        if (newWidth > maxWidth)
        {
            newWidth = maxWidth;
        }
 
        // change only the width, keep the same height
        transform.localScale = new Vector3(newWidth, transform.localScale.y, 1f);
    }
 
    void MakePaddleSmaller()
    {
        float newWidth = transform.localScale.x - widthChange;
 
        // do not go below the smallest allowed width
        if (newWidth < minWidth)
        {
            newWidth = minWidth;
        }
 
        transform.localScale = new Vector3(newWidth, transform.localScale.y, 1f);
    }
}
 

