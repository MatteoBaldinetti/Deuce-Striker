using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeHand : MonoBehaviour
{
    public GameObject leftHandRH;
    public GameObject rightHandRH;
    public GameObject leftHandLH;
    public GameObject rightHandLH;


    private static bool isLeftHand = false; // Variable statique pour suivre l'état de la main
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainScene" && isLeftHand == false)
        {
            leftHandRH.SetActive(true);
            rightHandRH.SetActive(true);
            leftHandLH.SetActive(false);
            rightHandLH.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "MainScene" && isLeftHand == true)
        {
            leftHandRH.SetActive(false);
            rightHandRH.SetActive(false);
            leftHandLH.SetActive(true);
            rightHandLH.SetActive(true);
        }
    }

    // Update is called once per frame
    public void switchHand()
    {
        if (isLeftHand == false)
        {
            isLeftHand = true;
            Debug.Log("Main gauche");
        }
        else
        {
            isLeftHand = false;
            Debug.Log("Main droite");
        }
    }
}
