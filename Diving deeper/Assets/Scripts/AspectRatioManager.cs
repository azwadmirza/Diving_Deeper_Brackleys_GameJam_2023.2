using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AspectRatioManager : MonoBehaviour
{
    public Vector2 aspectRatio = Vector2.zero;
    private bool fullScreen = false;
    // Start is called before the first frame update
    void Awake()
    {
        if(aspectRatio != Vector2.zero)
        {
            int x = Convert.ToInt32(Screen.height * (aspectRatio.x / aspectRatio.y));
            int y = Convert.ToInt32(Screen.height);

            Screen.SetResolution(x, y, fullScreen);
        }
    }
}
