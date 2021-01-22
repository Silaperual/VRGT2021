using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int m_scure=0;
    public int Scure { get { return m_scure; }set { m_scure = value; ScureText.text = value.ToString(); } }
    public Text ScureText;
    public GameObject[] en;
    public static GameManager Init;
    public Level1 level1;
    public static float MasterSpeed=3.5f;
    public static int MasterMaxHp=100;
    public static int MasterNumber=10;

    private void Awake()
    {
        Init = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       // StartLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
         
    }


    public static void StartLevel(int id)
    {
        if (id == 1)
        {
            foreach (var item in Init. en)
            {
                item.SetActive(false);
            }
            Init. level1.nEnter();
            Pvr_UnitySDKManager.SDK.transform.gameObject.AddComponent<MainRole>();
        }
    }
}
