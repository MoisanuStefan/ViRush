using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 2f;
    public GameObject enemy;
    float nextSpawn;
    Vector2 whereToSpawn;
    float randX;
    float randY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            randX = Random.Range(-9f, 4.5f);
            randY = Random.Range(-3.5f, 4f);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
        }
        
    }
}
