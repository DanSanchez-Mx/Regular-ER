using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager sharedInstance;

    public List<SpawnObjectScrpt> allEnemies = new List<SpawnObjectScrpt>();
    public List<SpawnObjectScrpt> currentEnemies = new List<SpawnObjectScrpt>();

    public Transform enemyStartPosition;

    public GameObject[] spawnPoints;
    public float timer;
    public float timeBetweenSpawns;

    public float speedMultipplier;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speedMultipplier += Time.deltaTime * .1f;
        timer += Time.deltaTime;

        if (timer > timeBetweenSpawns)
        {
            timer = 0;
            AddEnemies();
        }

        if (speedMultipplier > 6)
        {
            timeBetweenSpawns = 1;
        }
        else if (speedMultipplier > 10)
        {
            timeBetweenSpawns = .5f;
        }
    }

    public void AddEnemies()
    {
        int randomIdx = Random.Range(0, spawnPoints.Length);
        int randomObjects = Random.Range(0, allEnemies.Count);

        SpawnObjectScrpt enemy;

        if (currentEnemies.Count == 0)
        {
            enemy = Instantiate(allEnemies[randomObjects], spawnPoints[randomIdx].transform.position, Quaternion.identity);
        }
        else
        {
            enemy = Instantiate(allEnemies[randomObjects], spawnPoints[randomIdx].transform.position, Quaternion.identity);
        }

        enemy.transform.SetParent(this.transform, false);

        Vector3 correction = new Vector3(spawnPoints[randomIdx].transform.position.x, spawnPoints[randomIdx].transform.position.y, 0);
        enemy.transform.position = correction;
        currentEnemies.Add(enemy);

    }

    public void DestroyEnemy()
    {
        SpawnObjectScrpt oldEnemy = currentEnemies[0];
        currentEnemies.Remove(oldEnemy);
        Destroy(oldEnemy.gameObject);
    }

    public void DestroyEnemies()
    {
        while (currentEnemies.Count > 0)
        {
            DestroyEnemy();
        }
    }
}
