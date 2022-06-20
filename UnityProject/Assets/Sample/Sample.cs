using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine;

#if UNITY_IOS || UNITY_TVOS
public class NativeAPI {
    [DllImport("__Internal")]
    public static extern void showHostMainWindow(string lastColor);
}
#endif

public class Sample : MonoBehaviour
{
    public CameraPostProcessing cameraPostProcessing;
    public Material colorInverter;
    string lastColor = "";

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }

    private void showHostMainWindow(string colors)
    {
#if UNITY_ANDROID
        try
        {
            AndroidJavaClass jc = new AndroidJavaClass("com.company.product.OverrideUnityActivity");
            AndroidJavaObject overrideActivity = jc.GetStatic<AndroidJavaObject>("instance");
            overrideActivity.Call("showMainActivity", lastColor);
        } catch(Exception e)
        {
            Debug.LogError(e);
            throw;
        }
#elif UNITY_IOS || UNITY_TVOS
        NativeAPI.showHostMainWindow(lastColor);
#endif
    }

    public void ShowNative()
    {
        showHostMainWindow(lastColor);
    }

    public void Unload()
    {
        Application.Unload();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ClearCameraEffect()
    {
        lastColor = "usual";
        cameraPostProcessing.material = null;
    }

    public void InvertCameraColors()
    {
        lastColor = "inverted";
        cameraPostProcessing.material = colorInverter;
    }
}

