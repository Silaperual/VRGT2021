using Pvr_UnitySDKAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRole : MonoBehaviour
{
    DemoShooting shooting;
    bool lightcaon;
    private void Update()
    {
        shooting = GetComponentInChildren<DemoShooting>();
        //
        //if (Input.GetMouseButtonDown(0))
        //{
        //    ProjectileMover mover = shooting.Shoot();
        //    if (lightcaon)
        //    {
        //        mover.flash = null;
        //    }
        //    mover.OnEnter += (v) =>
        //    {
        //        Collider[] hits = Physics.OverlapSphere(v, 3);

        //        List<Matster> msa = new List<Matster>();
        //        foreach (var item in hits)
        //        {
        //            Matster matster = item.transform.GetComponentInParent<Matster>();


        //            if (matster != null && (!msa.Contains(matster)))
        //            {
        //                Debug.Log(matster.name);
        //                matster.Hp -= 10;
        //                msa.Add(matster);
        //            }

        //        }


        //    };

        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    shooting.Counter(1);
        //}
        if (Controller.UPvr_GetKeyDown(0, Pvr_KeyCode.TRIGGER))
        {
            lightcaon = !lightcaon;
        }
        if (Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.B))
        {
            shooting.Counter(1);
        }
        if (Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.A))
        {
            shooting.Counter(-1);
        }

        if (Controller.UPvr_GetKeyDown(1, Pvr_KeyCode.TRIGGER))
        {
            ProjectileMover mover = shooting.Shoot();
            if (lightcaon)
            {
                mover.flash = null;
            }
            //mover.OnEnter += (v) =>
            //{
            //    Collider[] hits = Physics.OverlapSphere(v, 3);

            //    List<Matster> msa = new List<Matster>();
            //    foreach (var item in hits)
            //    {
            //        Matster matster = item.transform.GetComponentInParent<Matster>();


            //        if (matster != null && (!msa.Contains(matster)))
            //        {
            //            Debug.Log(matster.name);
            //            matster.Hp -= 10;
            //            msa.Add(matster);
            //        }

            //    }


            //};

        };
    }
}

