using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChanger : MonoBehaviour
{
    public Material skyboxDay;
    public Material skyboxDawn;
    public Material skyboxNight;
    public static Material currentSkybox;

    public void changeSkybox(int v)
    {
        if (v == 0)
        {
            currentSkybox = skyboxDay;
        }
        else if (v == 1)
        {
            currentSkybox = skyboxDawn;
        }
        else if (v == 2)
        {
            currentSkybox = skyboxNight;
        }
    }
}
