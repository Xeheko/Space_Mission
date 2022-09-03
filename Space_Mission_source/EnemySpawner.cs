using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    
   public GameObject EnemyShip;
   public GameObject EnemyShipAim;
   public GameObject Meteor;
 //  public GameObject PurpCom;
   public MainScript MS;
   public Sprite[] meteoritSprites;


   
   
    // Start is called before the first frame update
    void Start()
    {
        MS = MainScript.GetInstance();
        Invoke ("SpawnEnemy", MS.maxSpawnRateInSeconds);
        Invoke ("IncreaseSpawnRate", 30f);
        Invoke ("SpawnMeteor", MS.maxSpawnRateInSeconds);
        Invoke ("SpawnEnemy2", MS.maxSpawnRateInSeconds);
    //    Invoke ("SpawnPurpCom", MS.maxSpawnRateInSeconds);
        meteoritSprites = Resources.LoadAll<Sprite>("meteorits");
        
       
    }
    void Update(){
       
    }

    // Update is called once per frame
   
    void SpawnEnemy(){
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        GameObject anEnemy = (GameObject)Instantiate (EnemyShip);

        anEnemy.transform.position = new Vector2 (Random.Range (min.x , max.x), max.y);
        ScheduleNextEnemySpawn ();
    }
    
            void ScheduleNextEnemySpawn()
            {
                
                float spawnInNSeconds;

                if(MS.maxSpawnRateInSeconds > 1.5f)
                {
                    spawnInNSeconds = Random.Range(1f, MS.maxSpawnRateInSeconds);
                }
                else
                spawnInNSeconds = 1f;
                Invoke ("SpawnEnemy", spawnInNSeconds);
            }
            void IncreaseSpawnrate()
            {
                if(MS.maxSpawnRateInSeconds > 1f)
                MS.maxSpawnRateInSeconds++;

                
            }

    void SpawnEnemy2(){
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));


        GameObject anEnemyAim = (GameObject)Instantiate (EnemyShipAim);

        anEnemyAim.transform.position = new Vector2 (Random.Range (min.x , max.x), max.y);
        ScheduleNextEnemySpawn2 ();
    }
    
            void ScheduleNextEnemySpawn2()
            {
                
                float spawnInNSeconds;

                if(MS.maxSpawnRateInSeconds > 1.5f)
                {
                    spawnInNSeconds = Random.Range(5f, MS.maxSpawnRateInSeconds);
                }
                else
                spawnInNSeconds = 3f;
                Invoke ("SpawnEnemy2", spawnInNSeconds);
            }
            void IncreaseSpawnrate2()
            {
                if(MS.maxSpawnRateInSeconds > 1f)
                MS.maxSpawnRateInSeconds++;

                
            }
        
        
        
        
        
     void SpawnMeteor(){
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        GameObject anMeteor = (GameObject)Instantiate (Meteor);
        Sprite ms = meteoritSprites[Random.Range(0, meteoritSprites.Length)];

        anMeteor.GetComponent<SpriteRenderer>().sprite = ms;



        anMeteor.transform.position = new Vector2 (Random.Range (min.x , max.x), max.y);
        ScheduleNextMeteorSpawn ();
    }
    
            void ScheduleNextMeteorSpawn()
            {
                
                float spawnInNSeconds;

                if(MS.maxSpawnRateInSeconds > 1.5f)
                {
                    spawnInNSeconds = Random.Range(1f, MS.maxSpawnRateInSeconds);
                }
                else
                spawnInNSeconds = 1f;
                Invoke ("SpawnMeteor", spawnInNSeconds);
            }

  /*      void SpawnPurpCom(){
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        GameObject anPurmCom = (GameObject)Instantiate (PurpCom);

        anPurmCom.transform.position = new Vector2 (Random.Range (min.x , max.x), max.y);
        ScheduleNextPurpComSpawn ();
    }
    
            void ScheduleNextPurpComSpawn()
            {
                
                float spawnInNSeconds;

                if(MS.maxSpawnRateInSeconds > 1.5f)
                {
                    spawnInNSeconds = Random.Range(1f, MS.maxSpawnRateInSeconds);
                }
                else
                spawnInNSeconds = 1f;
                Invoke ("SpawnPurpCom", spawnInNSeconds);
            } */


    }

