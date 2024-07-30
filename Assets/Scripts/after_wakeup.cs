using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class after_wakeup : MonoBehaviour
{

    [SerializeField] GameObject FPS_Cam;
    [SerializeField] GameObject FPS_Canvas;

    public void ActivateFPSCAM()
    {
        FPS_Cam.SetActive(true);
        FPS_Canvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
