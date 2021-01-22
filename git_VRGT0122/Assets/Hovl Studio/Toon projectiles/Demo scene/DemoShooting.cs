using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;

public class DemoShooting : MonoBehaviour
{
    public GameObject ControlPref; 
    public GameObject[] Prefabs;

    
    private int Prefab;
    private GameObject Instance;

    private GameObject dot;
    private void Awake()
    {
        ControlPref = this.gameObject;
        dot = ControlPref.transform.Find("dot").gameObject;

    }
    public ProjectileMover Shoot()
    {
        //Single shoot

        GameObject obj = Instantiate(Prefabs[Prefab], ControlPref.transform.position, Quaternion.LookRotation(dot.transform.position-transform.position)) ;
        return obj.GetComponent<ProjectileMover>();
     
    }

   
    public  void Counter(int count)
    {
        Prefab += count;
        if (Prefab > Prefabs.Length - 1)
        {
            Prefab = 0;
        }
        else if (Prefab < 0)
        {
            Prefab = Prefabs.Length - 1;
        }
    }

   
}
