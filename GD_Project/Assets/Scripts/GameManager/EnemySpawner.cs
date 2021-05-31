using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRateIncreaseFactor;
    public float spawnRateIncreaseInterval;

    public int maxSpawnRate = 2;
    public Healthbar quarantineTraker;
    public int quarantineTreshold = 3;
    public int deathTreshold = 6;
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
    private float lastIncreaseTime;
    private bool isRateIncreasing = true;


    private float[,] coords_x = { { -32f, -16f }, { -10f, 5.7f }, { 12f, 27f }, { 12f, 27f }, { -32f, -16f } };
    private float[,] coords_y = { { 6f, 18f }, { -5.6f, 6.2f }, { 6f, 18f }, { -6f, -12.5f }, { -6f, -12.5f } };


    // Start is called before the first frame update
    void Start()
    {
        isRateIncreasing = true;
        quarantineTraker.SetMaxHealth(deathTreshold);
        lastIncreaseTime = Time.time;
        quarantineEnabled = false;
        virusCount = 0;
        quarantineTraker.SetHealth(virusCount);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawnRate();
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
                quarantineTraker.SetHealth(virusCount);

                spawnedEnemy = Instantiate(virus, whereToSpawn, Quaternion.identity);
                spawnedEnemy.SendMessage("SetSpawner", this);
            }

            if (virusCount > deathTreshold)
            {
                SceneManager.LoadScene("MainScene");
            }
     
            
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
        quarantineTraker.SetHealth(virusCount);
        virusCount--;
    }

    private void UpdateSpawnRate()
    {
        if (isRateIncreasing && Time.time >= lastIncreaseTime + spawnRateIncreaseInterval)
        {
            spawnRate -= spawnRateIncreaseFactor;
            lastIncreaseTime = Time.time;
           if (spawnRate == maxSpawnRate)
            {
                isRateIncreasing = false;
            }
        }
    }
}
