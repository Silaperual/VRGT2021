using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float speed = 0;
    public float tileLength = 60;
    public int numberOfTiles = 3;
    private List<GameObject> activeTiles = new List<GameObject>();
    
    public Transform playerTransform;


    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
        }

    }
    void FixedUpdate()
    {
        if (activeTiles.Count==0)
        {
            return;
        }

        if (playerTransform.position.z - 0.3 > activeTiles[0].transform.position.z)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
        foreach (var item in activeTiles)
        {
            item.transform.Translate(Vector3.back*speed,Space.World);
        }
    }
    public void SpawnTile(int tileIndex)
    { 
        Vector3 pos;
        if (activeTiles.Count==0)
        {
            pos = new Vector3();
        }
        else
        {
            pos = activeTiles[activeTiles.Count - 1].transform.position+new Vector3(0,0,tileLength);
        }
        GameObject go = Instantiate(tilePrefabs[tileIndex],pos,Quaternion.identity);
        activeTiles.Add(go);
        //给子弹撞墙消失
        foreach (var item in go.GetComponentsInChildren<Collider>())
        {
            item.isTrigger = false;
        }
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}