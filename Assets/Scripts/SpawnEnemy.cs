using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject balloonGhostPrefab; // El prefab puede ser el enemigo u objeto que quieran
    public int spawnCount; // Número de enemigos que sale de forma aleatoria cada 5 segundos
    public float spawnDistance = 10f; // Distancia a la que aparecen los enemigos
    private GameObject[] spawnedEnemies; // Contador de enemigos que hicieron spawn

    void Start()
    {
        spawnCount = Random.Range(1, 6); // Genera un número aleatorio entre 1 y 5 para generar a los enemigos
        spawnedEnemies = new GameObject[spawnCount];
        InvokeRepeating("SpawnWave", 0f, 5f); // Spawnea enemigos cada 5 segundos, se puede cambiar por lo que gusten
    }

    void SpawnWave()
    {
        DestroyPreviousEnemies(); // Elimina los enemigos que ya salieron luego del tiempo

        spawnCount = Random.Range(1, 6); // Nueva cantidad aleatoria de enemigos que van a hacer spawn
        spawnedEnemies = new GameObject[spawnCount];

        for (int i = 0; i < spawnCount; i++)//Cuando no hay enemigos spawnea más
        {
            spawnedEnemies[i] = SpawnInFront();
        }
    }

    GameObject SpawnInFront()//Función para seguir a la cámara
    {
        Transform cameraTransform = Camera.main.transform;//Toma la posición actual de la cámara

        // Genera una posición frente a la cámara con un desplazamiento aleatorio pequeño para que los enemigos spawneen
        Vector3 spawnPosition = cameraTransform.position + (cameraTransform.forward * spawnDistance);
        spawnPosition += new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);

        return Instantiate(balloonGhostPrefab, spawnPosition, Quaternion.identity);
    }

    void DestroyPreviousEnemies()//Eliminar los enemigos que ya salieron
    {
        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
            {
                Destroy(enemy);
            }
        }
    }
}

