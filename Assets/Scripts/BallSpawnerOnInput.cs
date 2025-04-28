using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BallSpawnerOnInput : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float launchVelocityThreshold = 1.2f;
    public float launchForce = 10f;

    private InputDevice leftHandDevice;
    private GameObject currentBall = null;
    private Vector3 previousHandPosition;
    private bool triggerWasPressedLastFrame = false;
    private GameObject previousball = null;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devices);
        if (devices.Count > 0)
        {
            leftHandDevice = devices[0];
        }

        previousHandPosition = spawnPoint.position;
    }

    void Update()
    {
        if (leftHandDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed))
        {
            // Flanc montant : on vient juste d’appuyer
            if (triggerPressed && !triggerWasPressedLastFrame)
            {
                if (currentBall == null)
                {
                    SpawnBall();
                }
            }

            triggerWasPressedLastFrame = triggerPressed;
        }

        if (currentBall != null)
        {
            currentBall.transform.position = spawnPoint.position;

            Vector3 handVelocity = (spawnPoint.position - previousHandPosition) / Time.deltaTime;

            if (handVelocity.y > launchVelocityThreshold)
            {
                LaunchBall(handVelocity);
            }
        }

        previousHandPosition = spawnPoint.position;
    }

    void SpawnBall()
    {
        Destroy(previousball); // Supprime la balle précédente si elle existe
        currentBall = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        previousball = currentBall;
        Rigidbody rb = currentBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void LaunchBall(Vector3 velocity)
    {
        Rigidbody rb = currentBall.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;

            // Boost vertical : on augmente la composante Y (verticale)
            Vector3 upwardBoost = new Vector3(0, launchForce, 0); // Tu peux ajuster la valeur Y si tu veux qu'elle aille plus haut ou moins haut
            rb.velocity = velocity + upwardBoost;
        }

        currentBall = null;
    }

}
