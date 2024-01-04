using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject   spawnObjectCOIN;
    public GameObject[] spawnPointsCOIN;
    public float        timerCOIN;
    public float        timerBetweenSpawnCOIN;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerCOIN += Time.deltaTime;

        if(timerCOIN > timerBetweenSpawnCOIN)
        {
            timerCOIN = 0;
            int randNum = Random.Range(0, 3); 
            Instantiate(spawnObjectCOIN, spawnPointsCOIN[randNum].transform.position, Quaternion.identity);
        }
    }
}
