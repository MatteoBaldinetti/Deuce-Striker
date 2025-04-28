using UnityEngine;

public class TennisRaquette : MonoBehaviour
{
    public float frappeForceMultiplier = 12f;
    public LayerMask cibleLayer;
    public float detectionDistance = 30f;
    public float forceAimAssist = 1.0f; // 1 = 100% correction

    private Vector3 anciennePosition;
    private Vector3 derniereVitesse;
    public AudioClip sonFrappe;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        derniereVitesse = (transform.position - anciennePosition) / Time.deltaTime;
        anciennePosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody balleRb = other.GetComponent<Rigidbody>();
            if (balleRb != null)
            {
                Vector3 directionFrappe = derniereVitesse.normalized;
                float puissanceFrappe = derniereVitesse.magnitude;

                Transform cible = TrouverCibleProche(other.transform.position, out float distanceCible);

                if (cible != null)
                {
                    Vector3 directionVersCible = (cible.position - other.transform.position).normalized;

                    // Mélanger la frappe et la direction vers la cible en fonction du "forceAimAssist"
                    directionFrappe = Vector3.Slerp(directionFrappe, directionVersCible, forceAimAssist).normalized;
                }

                // Reset vitesse balle
                balleRb.velocity = Vector3.zero;

                // Appliquer la force
                balleRb.AddForce(directionFrappe * puissanceFrappe * frappeForceMultiplier, ForceMode.VelocityChange);
            }
            audioSource.PlayOneShot(sonFrappe);
        }
    }

    private Transform TrouverCibleProche(Vector3 positionBalle, out float distanceLaPlusProche)
    {
        Collider[] colliders = Physics.OverlapSphere(positionBalle, detectionDistance, cibleLayer);
        Transform cibleLaPlusProche = null;
        distanceLaPlusProche = Mathf.Infinity;

        foreach (var collider in colliders)
        {
            float distance = Vector3.Distance(positionBalle, collider.transform.position);
            if (distance < distanceLaPlusProche)
            {
                distanceLaPlusProche = distance;
                cibleLaPlusProche = collider.transform;
            }
        }

        return cibleLaPlusProche;
    }
}
