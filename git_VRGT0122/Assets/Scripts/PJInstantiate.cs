using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJInstantiate : MonoBehaviour
{
    public GameObject[] Prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ProjectileMover ShootPJL(Vector3 ori,Vector3 dir)
    {
        GameObject obj = Instantiate(Prefab[0],ori,Quaternion.LookRotation(dir));
        return obj.GetComponent<ProjectileMover>();
    }
    public ProjectileMover ShootPJR(Vector3 ori,Vector3 dir)
    {
        GameObject obj = Instantiate(Prefab[1],ori,Quaternion.LookRotation(dir));
        return obj.GetComponent<ProjectileMover>();
    }
}
