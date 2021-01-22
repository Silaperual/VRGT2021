using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Material Mat;
    [SerializeField]
   public float m_brightness = 1;
    [SerializeField]
    public float m_saturation = 0;
    [SerializeField]
    public float m_contrast = 0;

    protected   void OnRenderImage(RenderTexture src, RenderTexture dest)
    { 
        Mat.SetFloat("_Brightness", m_brightness);
        Mat.SetFloat("_Saturation", m_saturation);
        Mat.SetFloat("_Contrast", m_contrast);
        Graphics.Blit(src, dest, Mat);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
