using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public GameObject view;
    bool isActive = true;
    public void ChangeCameraView()
    {
        view.SetActive(isActive);
        isActive = !isActive;
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
