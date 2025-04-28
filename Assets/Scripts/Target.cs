using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue = 1;

    void Start()
    {
        TargetSpawner targetSpawner = FindObjectOfType<TargetSpawner>();
        if (targetSpawner != null)
        {
            targetSpawner.targetAlive++;
        }
        else
        {
            Debug.LogError("TargetSpawner not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<ScoreManager>().addScore(scoreValue);
            TargetSpawner targetSpawner = FindObjectOfType<TargetSpawner>();
            if (targetSpawner != null)
            {
                targetSpawner.targetAlive--;
            }
            else
            {
                Debug.LogError("TargetSpawner not found in the scene.");
            }
            Destroy(gameObject); // Supprime la cible après impact
            Destroy(other.gameObject); // Supprime la balle après impact

        }
    }
}
