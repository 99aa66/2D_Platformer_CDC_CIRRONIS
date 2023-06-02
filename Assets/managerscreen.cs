using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerscreen : MonoBehaviour
{
    void Start()
    {
        SetResolution(1920, 1080);
    }

    void SetResolution(int width, int height)
    {
        Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
    }
}
