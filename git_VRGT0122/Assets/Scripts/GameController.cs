using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] enemy;
    public Vector3[] spawnPoints;
    public Vector3 spawnValues;
    private int enemyIndex;
    private int pointsIndex;
    public Transform gameController;

    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                pointsIndex = Random.Range(0, spawnPoints.Length);
                spawnValues = spawnPoints[pointsIndex];
                Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                enemyIndex = Random.Range(0, enemy.Length);
                Instantiate(enemy[enemyIndex], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
