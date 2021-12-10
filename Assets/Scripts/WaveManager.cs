using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //Object to target when spawning
    public GameObject spawnTarget;

    //Phill added GameObject to be Spawned!
    public GameObject Enemy_Prefab;

    // Spawn delay is time between enemiy spawning 
    public float spawnDelay;
    //Wave delay is time between end and beginning of new wave 
    public float waveDelay; 

    //_spawnTimer manages the spawn delay  
    private float _spawnTimer;
    
    //_waveTimer managers the Wave Delay 
    private float _waveTimer;

    //Track spawning locations 
    private GameObject[] _spawners;

    //Amount of Enemies per wave 
    public int[] enemyAmount;

    // The current Wave number 
    public int waveNumber;

    //; Bool for wave delay 
    public bool nextWave;

    private bool _completed; 

    // Start is called before the first frame update
    void Awake()
    {
        _spawners = GameObject.FindGameObjectsWithTag("Spawnpoint");
        _spawnTimer = spawnDelay; 
    }

    // Update is called once per frame
    void Update()
    {
        if(!_completed)
        {
            if (nextWave)
            {
                if (_waveTimer <= 0.1f)
                {
                    TriggerNextWave();
                }
                else
                {
                    _waveTimer -= Time.deltaTime;
                }
            }
            if (_spawnTimer <= 0.1f)
            {
                SpawnEnemy();
            }
            else
            {
                _spawnTimer -= Time.deltaTime;
            }
        }
        
    }

    public void SpawnEnemy()
    {
        if(enemyAmount[waveNumber] > 0)
        {
            //ADD INSTANTIATE CODE HERE 
            GameObject enemy = Instantiate(Enemy_Prefab, this.transform.position, Quaternion.identity);
            enemy.GetComponent<Enemies>().SetTarget(spawnTarget.transform.position);


            Debug.Log("Spawn Enemy");
            _spawnTimer = spawnDelay;
            enemyAmount[waveNumber] -= 1;
        }
        else if(!nextWave)
        {
            nextWave = true;
            _waveTimer = waveDelay; 

        }
         
    }
    public void TriggerNextWave()
    {
        if(waveNumber == enemyAmount.Length -1)
        {
            Debug.Log("No More Waves!");
            _completed = true;
        }
        else
        {
            Debug.Log("Next Wave!!");
            waveNumber += 1;
            
        }
        nextWave = false;




    }
}
