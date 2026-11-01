using UnityEngine;
 
public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject bombPrefab;
    public GameObject growPrefab;
    public GameObject shrinkPrefab;
    public GameManager gameManager;
 
    public float spawnTime = 0.8f;
    public int bombChance = 20;
    public int growChance = 10;
    public int shrinkChance = 10;
 
    public float minX = -8f;
    public float maxX = 8f;
    public float spawnY = 6f;
 
    float timer = 0f;
 
    void Update()
    {
        if (gameManager.isGameOver == false)
        {
            timer = timer + Time.deltaTime;
 
            if (timer >= spawnTime)
            {
                timer = 0f;
                SpawnItem();
            }
        }
    }
 
    void SpawnItem()
    {
        float x = Random.Range(minX, maxX);
        Vector3 position = new Vector3(x, spawnY, 0f);
 
        int number = Random.Range(0, 100);
 
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