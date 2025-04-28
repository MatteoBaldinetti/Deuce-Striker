using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTimeOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = TimeChanger.currentSkybox;
    }

    void Awake()
    {

    }
}
