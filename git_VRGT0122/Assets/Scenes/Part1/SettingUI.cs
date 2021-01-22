using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField]
    private GameObject left_contrast;
    [SerializeField]
    private GameObject left_brightness;
    [SerializeField]
    private GameObject left_saturation;
    [SerializeField]
    private GameObject right_contrast;
    [SerializeField]
    private GameObject right_brightness;
    [SerializeField]
    private GameObject right_saturation;

    public void Awake()
    {
        Slider slider1 = left_contrast.transform.Find("Slider").GetComponent<Slider>();
        Text value1 = left_contrast.transform.Find("value").GetComponent<Text>();
        slider1.onValueChanged.AddListener((value) =>
        {
            Debug.Log(11);
            value1.text = value.ToString();
            Pvr_UnitySDKEyeManager.Instance.LeftEyeCamera.GetComponent<CameraControl>().m_contrast = value;
        });

        Slider slider2 = left_brightness.transform.Find("Slider").GetComponent<Slider>();
        Text value2 = left_brightness.transform.Find("value").GetComponent<Text>();
        slider2.onValueChanged.AddListener((value) =>
        {
            value2.text = value.ToString();
            Pvr_UnitySDKEyeManager.Instance.LeftEyeCamera.GetComponent<CameraControl>().m_brightness = value;
        });

        Slider slider3 = left_saturation.transform.Find("Slider").GetComponent<Slider>();
        Text value3 = left_saturation.transform.Find("value").GetComponent<Text>();
        slider3.onValueChanged.AddListener((value) =>
        {
            value3.text = value.ToString();
            Pvr_UnitySDKEyeManager.Instance.LeftEyeCamera.GetComponent<CameraControl>().m_saturation = value;
        });



        Slider slider4 = right_contrast.transform.Find("Slider").GetComponent<Slider>();
        Text value4 = right_contrast.transform.Find("value").GetComponent<Text>();
        slider4.onValueChanged.AddListener((value) =>
        {
            value4.text = value.ToString();
            Pvr_UnitySDKEyeManager.Instance.RightEyeCamera.GetComponent<CameraControl>().m_contrast = value;
        });

        Slider slider5 = right_brightness.transform.Find("Slider").GetComponent<Slider>();
        Text value5 = right_brightness.transform.Find("value").GetComponent<Text>();
        slider5.onValueChanged.AddListener((value) =>
        {
            value5.text = value.ToString();
            Pvr_UnitySDKEyeManager.Instance.RightEyeCamera.GetComponent<CameraControl>().m_brightness = value;
        });

        Slider slider6 = right_saturation.transform.Find("Slider").GetComponent<Slider>();
        Text value6 = right_saturation.transform.Find("value").GetComponent<Text>();
        slider6.onValueChanged.AddListener((value) =>
        {
            value6.text = value.ToString();
            Pvr_UnitySDKEyeManager.Instance.RightEyeCamera.GetComponent<CameraControl>().m_saturation = value;
        });
    }
   
    
}
