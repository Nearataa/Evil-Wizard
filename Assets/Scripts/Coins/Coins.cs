using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float spawnInterval = 3f;  // Time between spawns
    public Vector2 spawnAreaMin;  // The minimum X and Y values for the spawn area
    public Vector2 spawnAreaMax;  // The maximum X and Y values for the spawn area

    public int maxSpawnCount;

    public GameObject objectToInstantiate; 
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
        
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found. Please ensure you have a Camera tagged as MainCamera.");
            return;
        }
        
        for (int i = 0; i < maxSpawnCount; i++)
        {
            Invoke("SpawnObject", 0);
        }
        //InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }
    
    void SpawnObject()
    {
        
        // Generate random position within the specified range
        Vector2 spawnPosition = GetRandomPositionInView();

        // Instantiate the object at the random position
        Instantiate(objectToInstantiate, spawnPosition, Quaternion.identity);
    }
    
    Vector2 GetRandomPositionInView()
    {
        // Get the main camera's position in the world
        Vector3 cameraPos = mainCamera.transform.position;

        // Calculate the orthographic size and aspect ratio
        float height = 2f * mainCamera.orthographicSize;
        float width = height * mainCamera.aspect;

        // Calculate the spawn area within the camera's view
        float minX = cameraPos.x - width / 2f;
        float maxX = cameraPos.x + width / 2f;
        float minY = cameraPos.y - height / 2f;
        float maxY = cameraPos.y + height / 2f;

        // Generate a random position within these boundaries
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }
}
