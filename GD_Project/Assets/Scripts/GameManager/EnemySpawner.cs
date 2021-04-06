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

    private float[,] coords_x = { { -32f, -16f }, { -10f, 5.7f }, { 12f, 27f }, { 12f, 27f }, { -32f, -16f } };
    private float[,] coords_y = { { 6f, 18f }, { -5.6f, 6.2f }, { 6f, 18f }, { -6f, -12.5f }, { -6f, -12.5f } };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if(Time.time > nextSpawn)
        {
            int random_area = Random.Range(0, 5);
            randX = Random.Range(coords_x[random_area, 0], coords_x[random_area, 1]);
            randY = Random.Range(coords_y[random_area, 0], coords_y[random_area, 1]);
            whereToSpawn = new Vector2(randX, randY);
            GameObject spawnedEnemy = Instantiate(enemy, whereToSpawn, Quaternion.identity);
            spawnedEnemy.GetComponent<EnemyMovement>().playArea = random_area;
            nextSpawn = Time.time + spawnRate;
        }
        
    }
}
