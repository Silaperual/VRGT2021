using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusChange : MonoBehaviour
{
    private Transform shieldObj;
    private Transform collectionObj;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        shieldObj = transform.GetChild(0);
        collectionObj = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldObj != null)
            return;
        else if(shieldObj == null&&collectionObj != null)
        {
            collectionObj.GetComponent<MeshRenderer>().material = material;
            collectionObj.tag = "Collection";
        }
    }
}
