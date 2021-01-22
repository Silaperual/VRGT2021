using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pvr_UnitySDKAPI;
using UnityEngine.UI;

public class ShootPJ : MonoBehaviour
{
    public GameObject controller0;
    public GameObject controller1;
    public Text starText;
    public Text killText;
    //ray_alpha0
    //ray_alpha1
    //可以更换下名字

    private GameObject dot0;
    private GameObject dot1;

    private int starPoint;
    private int killPoint;

    PJInstantiate shootPJ;
    bool lightcaon;
    // Start is called before the first frame update
    void Start()
    {
        starPoint = 0;
        killPoint = 0;
        dot0 = controller0.transform.Find("ray_alpha").gameObject;
        dot1 = controller1.transform.Find("ray_alpha").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        shootPJ = GetComponentInChildren<PJInstantiate>();
        if (Controller.UPvr_GetControllerState(0) == ControllerState.Connected || Controller.UPvr_GetControllerState(1) == ControllerState.Connected)
        {
            if (Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.A))
            {
                lightcaon = !lightcaon;
            }
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
#else
           if (Controller.UPvr_GetKeyDown(0, Pvr_KeyCode.TRIGGER))
#endif


        {
            Transform startT = controller0.transform.Find("start");
            ProjectileMover mover = shootPJ.ShootPJL(startT.position, (dot0.transform.position - startT.position).normalized);
            if (lightcaon)
            {
                mover.flash = null;
            }
            mover.CollisionEnterEvt += (v) =>
            {
                Collider[] hits = Physics.OverlapSphere(v.contacts[0].point, 5);
                foreach (var item in hits)
                {
                    if (item.transform.gameObject.tag == "Collection" || item.transform.gameObject.tag == "Shield")
                    {
                        Destroy(item.transform.gameObject);
                    }
                }
            };
            killPoint += 20;
            killText.text = killPoint.ToString();
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(1))
#else
              if (Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.TRIGGER))
#endif


        {
            Transform startT = controller1.transform.Find("start");
            ProjectileMover mover = shootPJ.ShootPJL(startT.position, (dot1.transform.position - startT.position).normalized);


            //   ProjectileMover mover = shootPJ.ShootPJR(controller1.transform.Find("start").position, controller1.transform.forward - controller1.transform.up * 0.25f);
            if (lightcaon)
            {
                mover.flash = null;
            }
            mover.CollisionEnterEvt += (v) =>
            {

                Collider[] hits = Physics.OverlapSphere(v.contacts[0].point, 5);

                foreach (var item in hits)
                {

                    if (item.transform.gameObject.tag == "Collection" || item.transform.gameObject.tag == "Shield")
                    {
                        Destroy(item.transform.gameObject);
                    }
                }
            };
            starPoint += 10;
            starText.text = starPoint.ToString();
        }
    }
}