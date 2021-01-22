using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSettingUI : MonoBehaviour
{
    [SerializeField]
    private GameObject speedSetting;
    [SerializeField]
    private GameObject maxHpSetting;
    [SerializeField]
    private GameObject maxNumberSetting;
    [SerializeField]
    private Button startButton;
    private void Awake()
    {
        Slider speed = speedSetting.transform.Find("Slider").GetComponent<Slider>();
        Text value1= speedSetting.transform.Find("value").GetComponent<Text>();
        speed.onValueChanged.AddListener((value) =>
        {
            GameManager.MasterSpeed = value;
            value1.text = value.ToString();
        });

        Slider maxHp = maxHpSetting.transform.Find("Slider").GetComponent<Slider>();
        Text value2 = maxHpSetting.transform.Find("value").GetComponent<Text>();
        maxHp.onValueChanged.AddListener((value) =>
        {
            GameManager.MasterMaxHp = (int)value;
            value2.text = value.ToString();
        });

        Slider maxNumber = maxNumberSetting.transform.Find("Slider").GetComponent<Slider>();
        Text value3 = maxNumberSetting.transform.Find("value").GetComponent<Text>();
        maxNumber.onValueChanged.AddListener((value) =>
        {
            GameManager.MasterNumber = (int)value;
            value3.text = value.ToString();
        });

        //startButton.onClick.AddListener(On4);
    }
 
    public void On4()
    {
        GameManager.StartLevel(1);
    }
}
