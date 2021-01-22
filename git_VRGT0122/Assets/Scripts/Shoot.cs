using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pvr_UnitySDKAPI;
using System.Threading;

public class Shoot : MonoBehaviour
{
    public GameObject[] Prefab;
    //The focus of the object's "attach" movement(left hand / right hand)

    public GameObject controller0;
    public GameObject controller1;
    private GameObject dot0;
    private GameObject dot1;
    private GameObject[] obj;
    private ProjectileMover[] mover;

    bool lightcaon;
    // Start is called before the first frame update
    // Update is called once per frame

    private void Awake()
    {
        dot0 = controller0.transform.Find("dot").gameObject;
        dot1 = controller1.transform.Find("dot").gameObject;
    }

    void Update()
    {
        if (Controller.UPvr_GetControllerState(0) == ControllerState.Connected || Controller.UPvr_GetControllerState(1) == ControllerState.Connected)
        {
            if (Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.A))
            {
                lightcaon = !lightcaon;
            }

            if (Controller.UPvr_GetKeyDown(0, Pvr_KeyCode.TRIGGER))
            {
                obj[0] = Instantiate(Prefab[0], controller0.transform.Find("start").position, Quaternion.LookRotation(dot0.transform.position-controller0.transform.position));
                mover[0] = obj[0].GetComponent<ProjectileMover>();
                if (lightcaon)
                {
                    mover[0].flash = null;
                }
                //mover[0].OnEnter += (v) =>
                //{
                //    Collider[] hits = Physics.OverlapSphere(v, 3);
                //    foreach (var item in hits)
                //    {
                //        if (item.transform.gameObject.tag == "collection"|| item.transform.gameObject.tag == "shield")
                //        {
                //            Destroy(item.transform.gameObject);
                //        }
                //    } 
                //};
            }

            if(Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.TRIGGER))
            {
                obj[1] = Instantiate(Prefab[1], controller1.transform.Find("start").position,Quaternion.LookRotation(dot1.transform.position-controller1.transform.position));
                mover[1] = obj[1].GetComponent<ProjectileMover>();
                if (lightcaon)
                {
                    mover[1].flash = null;
                }

                //mover[1].OnEnter += (v) =>
                //{
                //    Collider[] hits = Physics.OverlapSphere(v, 3);
                //    foreach (var item in hits)
                //    {
                //        if (item.transform.gameObject.tag == "collection"||item.transform.gameObject.tag == "shield")
                //        {
                //            Destroy(item.transform.gameObject);
                //        }
                //    }
                //};
            }
        }
    }


}
