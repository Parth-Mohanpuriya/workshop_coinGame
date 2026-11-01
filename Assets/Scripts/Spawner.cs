using UnityEngine;
 
public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;      // drag the Coin prefab here
    public GameObject bombPrefab;      // drag the Bomb prefab here
    public GameObject growPrefab;      // drag the Grow prefab here
    public GameObject shrinkPrefab;    // drag the Shrink prefab here
    public GameManager gameManager;    // drag the GameManager object here
 
    public float spawnTime = 0.8f;     // seconds to wait between drops
    public int bombChance = 20;        // about 20 out of 100 drops are bombs
    public int growChance = 10;        // about 10 out of 100 drops make the paddle longer
    public int shrinkChance = 10;      // about 10 out of 100 drops make the paddle shorter
    // the drops left over (about 60 out of 100) are coins
 
    public float minX = -8f;           // leftmost place an item can appear
    public float maxX = 8f;            // rightmost place an item can appear
    public float spawnY = 6f;          // height where items appear (above the screen)
 
    float timer = 0f;                  // counts seconds since the last drop
 
    void Update()
    {
        // Only spawn if the game is not over
        if (gameManager.isGameOver == false)
        {
            // add the time of this frame to the timer
            timer = timer + Time.deltaTime;
 
            // is it time for a new item?
            if (timer >= spawnTime)
            {
                timer = 0f;      // start counting again
                SpawnItem();     // run the function below
            }
        }
    }
 
    void SpawnItem()
    {
        // pick a random x position
        float x = Random.Range(minX, maxX);
        Vector3 position = new Vector3(x, spawnY, 0f);
 
        // pick a random whole number from 0 to 99
        int number = Random.Range(0, 100);
 
        // numbers below bombChance are bombs,
        // the next growChance numbers are grow items,
        // the next shrinkChance numbers are shrink items,
        // everything else is a coin
        int growLimit = bombChance + growChance;
        int shrinkLimit = growLimit + shrinkChance;
 
        if (number < bombChance)
        {
            Instantiate(bombPrefab, position, Quaternion.identity);
        }
        else if (number < growLimit)
        {
            Instantiate(growPrefab, position, Quaternion.identity);
        }
        else if (number < shrinkLimit)
        {
            Instantiate(shrinkPrefab, position, Quaternion.identity);
        }
        else
        {
            Instantiate(coinPrefab, position, Quaternion.identity);
        }
    }
}