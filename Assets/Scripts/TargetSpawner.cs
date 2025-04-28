using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // Le prefab de la cible
    public Transform wallSurface; // La surface du mur
    public float spawnInterval = 2.0f; // Intervalle de spawn en secondes
    public int targetAlive = 0;


    private List<GameObject> activeTargets = new List<GameObject>();

    void Start()
    {
        SpawnTarget();
    }


    void SpawnTarget()
    {
        Vector3 spawnPosition = GetRandomPositionOnWall();
        GameObject newTarget = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        activeTargets.Add(newTarget);
    }

    void Update()
    {
        // Vérifiez si le nombre de cibles actives est inférieur au maximum
        if (targetAlive == 0)
        {
            SpawnTarget();
        }
    }

    Vector3 GetRandomPositionOnWall()
    {
        // Assurez-vous que le mur a un MeshFilter et que les bounds sont corrects
        Mesh mesh = wallSurface.GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;

        // Générer des positions aléatoires dans les limites du mur
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        // Assurez-vous que la position est sur la surface du mur
        Vector3 randomPosition = new Vector3(wallSurface.position.x - 2f, randomY, randomZ);
        return wallSurface.TransformPoint(randomPosition);
    }
}
