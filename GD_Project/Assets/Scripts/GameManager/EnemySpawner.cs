using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int quarantineTreshold = 20;
    public float spawnRate = 2f;
    public GameObject virus;
    public GameObject bat;
    float nextSpawn;
    Vector2 whereToSpawn;
    float randX;
    float randY;
    private int virusCount = 0;
    public QuarantineController quarantine;
    public Teleport teleport;
    private bool quarantineEnabled = false;



    private float[,] coords_x = { { -32f, -16f }, { -10f, 5.7f }, { 12f, 27f }, { 12f, 27f }, { -32f, -16f } };
    private float[,] coords_y = { { 6f, 18f }, { -5.6f, 6.2f }, { 6f, 18f }, { -6f, -12.5f }, { -6f, -12.5f } };


    // Start is called before the first frame update
    void Start()
    {
        quarantineEnabled = false;
        virusCount = 0;
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
            GameObject spawnedEnemy;
            int randomNumber = Random.Range(0, 20);

            whereToSpawn = transform.position + Vector3.up * 1.5f;

            if (randomNumber > 17)
            {
                spawnedEnemy = Instantiate(bat, whereToSpawn, Quaternion.identity);
            }
            else
            {
                virusCount++;
                spawnedEnemy = Instantiate(virus, whereToSpawn, Quaternion.identity);
            }
            spawnedEnemy.SendMessage("SetSpawner", this);
            
     
           
            nextSpawn = Time.time + spawnRate;
            if (virusCount >= quarantineTreshold && !quarantineEnabled)
            {
                quarantineEnabled = true;
                quarantine.StartQuarantine();
                teleport.SetDisabledValue(true);
            }
            else if (virusCount < quarantineTreshold && quarantineEnabled)
            {
                quarantineEnabled = false;
                quarantine.EndQuarantine();
                teleport.SetDisabledValue(false);
            }
        }
        
    }
    public void DecreaseVirusCount()
    {
        virusCount--;
    }
}
