using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject obj;
   public Transform[] points;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void  nEnter( )
    {
        StartCoroutine(CreatMaster());

    }
    IEnumerator CreatMaster()
    {
        for (int i = 0; i < GameManager.MasterNumber; i++)
        {
           int random=   Random.Range(0, 3);
            Vector3 v = points[random].GetChild(0).transform.position;
            GameObject clone = GameObject.Instantiate<GameObject>(obj, v, Quaternion.identity);
            clone.name += i;
            Matster matster = clone.GetComponent<Matster>();
            List<Vector3> pos = new List<Vector3>();
            foreach (Transform item in points[random])
            {
                pos.Add(item.position);
            }
            matster.SetPos(pos.ToArray());
            yield return new WaitForSeconds(10);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
